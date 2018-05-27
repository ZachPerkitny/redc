using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Redc.Browser.Utils;

namespace Redc.Browser.Html.Parser
{
    internal class HtmlTokenizer : Tokenizer
    {
        private readonly Queue<HtmlToken> _tokens;

        private readonly StringBuilder _temporaryBuffer;
        private string _lastEmittedStartTag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public HtmlTokenizer(string source)
            : base(source)
        {
            // used when multiple tokens are emitted
            _tokens = new Queue<HtmlToken>();

            _temporaryBuffer = new StringBuilder();
            _lastEmittedStartTag = string.Empty;

            State = HtmlTokenizerState.DataState;
        }

        /// <summary>
        /// 
        /// </summary>
        public HtmlTokenizerState State { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HtmlToken GetToken()
        {
            HtmlToken token = null;
            HtmlTokenizerState returnState;

            // while no tokens have been emitted
            while (_tokens.Count == 0)
            {
                char ch = Consume();

                switch (State)
                {
                    // Reference: https://www.w3.org/TR/html5/syntax.html#data-state
                    case HtmlTokenizerState.DataState:
                        {
                            switch (ch)
                            {
                                case Symbols.Ampersand:
                                    returnState = HtmlTokenizerState.DataState;
                                    //State = HtmlTokenizerState.CharacterReference;
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.TagOpenState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    EmitCharacterToken(ch);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#RCDATA-state
                    case HtmlTokenizerState.RCDATAState:
                        {
                            switch (ch)
                            {
                                case Symbols.Ampersand:
                                    returnState = HtmlTokenizerState.RCDATAState;
                                    //State = HtmlTokenizerState.CharacterReference;
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.RCDATALessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#rawtext-state
                    case HtmlTokenizerState.RAWTEXTState:
                        {
                            switch (ch)
                            {
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.RAWTEXTLessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-state
                    case HtmlTokenizerState.ScriptDataState:
                        {
                            switch (ch)
                            {
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataLessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#plaintext-state
                    case HtmlTokenizerState.PLAINTEXTState:
                        {
                            switch (ch)
                            {
                                case Symbols.Null:
                                    ParseError();
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#tag-open-state
                    case HtmlTokenizerState.TagOpenState:
                        {
                            switch (ch)
                            {
                                case Symbols.ExclamationMark:
                                    break;
                                case Symbols.Solidus:
                                    State = HtmlTokenizerState.EndTagOpenState;
                                    break;
                                case Symbols.QuestionMark:
                                    ParseError();
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    if (char.IsLetter(ch))
                                    {
                                        token = new HtmlToken();
                                        token.BeginStartTag();
                                        ReconsumeIn(HtmlTokenizerState.TagNameState);
                                    }
                                    else
                                    {
                                        ParseError();
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        ReconsumeIn(HtmlTokenizerState.DataState);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#end-tag-open-state
                    case HtmlTokenizerState.EndTagOpenState:
                        {
                            switch (ch)
                            {
                                case Symbols.GreaterThanSign:
                                    ParseError();
                                    State = HtmlTokenizerState.DataState;
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    EmitCharacterToken(Symbols.Solidus);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    if (char.IsLetter(ch))
                                    {
                                        token = new HtmlToken();
                                        token.BeginEndTag();

                                        ReconsumeIn(HtmlTokenizerState.TagNameState);
                                    }
                                    else
                                    {
                                        ParseError();
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#tag-name-state
                    case HtmlTokenizerState.TagNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    break;
                                case Symbols.Solidus:
                                    break;
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    token.AppendToName(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        token.AppendToName(char.ToLower(ch));
                                    }
                                    else
                                    {
                                        token.AppendToName(ch);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#RCDATA-less-than-sign-state
                    case HtmlTokenizerState.RCDATALessThanSignState:
                        {
                            if (ch == Symbols.Solidus)
                            {
                                _temporaryBuffer.Clear();
                                State = HtmlTokenizerState.RCDATAEndTagOpenState;
                            }
                            else
                            {
                                EmitCharacterToken(Symbols.LessThanSign);
                                ReconsumeIn(HtmlTokenizerState.RCDATAState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#RCDATA-end-tag-open-state
                    case HtmlTokenizerState.RCDATAEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                token = new HtmlToken();
                                token.BeginEndTag();
                                ReconsumeIn(HtmlTokenizerState.RCDataEndTagNameState);
                            }
                            else
                            {
                                EmitCharacterToken(Symbols.LessThanSign);
                                EmitCharacterToken(Symbols.Solidus);
                                ReconsumeIn(HtmlTokenizerState.RCDATAState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#RCDATA-end-tag-name-state
                    case HtmlTokenizerState.RCDataEndTagNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.Solidus:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.GreaterThanSign:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        State = HtmlTokenizerState.DataState;
                                        break;
                                    }
                                    goto default;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        token.AppendToName(char.ToLower(ch));
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else if (char.IsLower(ch))
                                    {
                                        token.AppendToName(ch);
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else
                                    {
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        EmitCharacterToken(Symbols.Solidus);
                                        EmitTemporaryBuffer();
                                        ReconsumeIn(HtmlTokenizerState.RCDATAState);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#rawtext-less-than-sign-state
                    case HtmlTokenizerState.RAWTEXTLessThanSignState:
                        {
                            if (ch == Symbols.Solidus)
                            {
                                _temporaryBuffer.Clear();
                                State = HtmlTokenizerState.RAWTEXTEndTagOpenState;
                            }
                            else
                            {
                                EmitCharacterToken(Symbols.LessThanSign);
                                ReconsumeIn(HtmlTokenizerState.RAWTEXTState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#rawtext-end-tag-open-state
                    case HtmlTokenizerState.RAWTEXTEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                token = new HtmlToken();
                                token.BeginEndTag();
                                ReconsumeIn(HtmlTokenizerState.RAWTextEndTagNameState);
                            }
                            else
                            {
                                EmitCharacterToken(Symbols.LessThanSign);
                                EmitCharacterToken(Symbols.Solidus);
                                ReconsumeIn(HtmlTokenizerState.RAWTEXTState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#rawtext-end-tag-name-state
                    case HtmlTokenizerState.RAWTextEndTagNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.Solidus:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.GreaterThanSign:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        State = HtmlTokenizerState.DataState;
                                        break;
                                    }
                                    goto default;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        token.AppendToName(char.ToLower(ch));
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else if (char.IsLower(ch))
                                    {
                                        token.AppendToName(ch);
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else
                                    {
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        EmitCharacterToken(Symbols.Solidus);
                                        EmitTemporaryBuffer();
                                        ReconsumeIn(HtmlTokenizerState.RAWTEXTState);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-less-than-sign-state
                    case HtmlTokenizerState.ScriptDataLessThanSignState:
                        {
                            switch (ch)
                            {
                                case Symbols.Solidus:
                                    _temporaryBuffer.Clear();
                                    State = HtmlTokenizerState.ScriptDataEndTagOpenState;
                                    break;
                                case Symbols.ExclamationMark:
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    EmitCharacterToken(Symbols.ExclamationMark);
                                    //State = 
                                    break;
                                default:
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    ReconsumeIn(HtmlTokenizerState.ScriptDataState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-end-tag-open-state
                    case HtmlTokenizerState.ScriptDataEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                token = new HtmlToken();
                                token.BeginEndTag();
                                ReconsumeIn(HtmlTokenizerState.ScriptDataEndTagNameState);
                            }
                            else
                            {
                                EmitCharacterToken(Symbols.LessThanSign);
                                EmitCharacterToken(Symbols.Solidus);
                                ReconsumeIn(HtmlTokenizerState.ScriptDataState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-end-tag-name-state
                    case HtmlTokenizerState.ScriptDataEndTagNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.Solidus:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.GreaterThanSign:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        State = HtmlTokenizerState.DataState;
                                        break;
                                    }
                                    goto default;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        token.AppendToName(char.ToLower(ch));
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else if (char.IsLower(ch))
                                    {
                                        token.AppendToName(ch);
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else
                                    {
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        EmitCharacterToken(Symbols.Solidus);
                                        EmitTemporaryBuffer();
                                        ReconsumeIn(HtmlTokenizerState.ScriptDataState);
                                    }
                                    break;
                                }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escape-start-state
                    case HtmlTokenizerState.ScriptDataEscapeStartState:
                        {
                            if (ch == Symbols.HyphenMinus)
                            {
                                State = HtmlTokenizerState.ScriptDataEscapeStartDashState;
                                EmitCharacterToken(Symbols.HyphenMinus);
                            }
                            else
                            {
                                ReconsumeIn(HtmlTokenizerState.ScriptDataState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escape-start-dash-state
                    case HtmlTokenizerState.ScriptDataEscapeStartDashState:
                        {
                            if (ch == Symbols.HyphenMinus)
                            {
                                State = HtmlTokenizerState.ScriptDataEscapedDashState;
                                EmitCharacterToken(Symbols.HyphenMinus);
                            }
                            else
                            {
                                ReconsumeIn(HtmlTokenizerState.ScriptDataState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escaped-state
                    case HtmlTokenizerState.ScriptDataEscapedState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    State = HtmlTokenizerState.ScriptDataEscapedDashState;
                                    EmitCharacterToken(Symbols.HyphenMinus);
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataEscapedLessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escaped-dash-state
                    case HtmlTokenizerState.ScriptDataEscapedDashState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    State = HtmlTokenizerState.ScriptDataEscapedDashDashState;
                                    EmitCharacterToken(Symbols.HyphenMinus);
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataEscapedLessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    State = HtmlTokenizerState.ScriptDataEscapedState;
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    State = HtmlTokenizerState.ScriptDataEscapedState;
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escaped-dash-dash-state
                    case HtmlTokenizerState.ScriptDataEscapedDashDashState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    EmitCharacterToken(Symbols.HyphenMinus);
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataEscapedLessThanSignState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.ScriptDataState;
                                    EmitCharacterToken(Symbols.GreaterThanSign);
                                    break;
                                case Symbols.Null:
                                    break;
                                case Symbols.EndOfFileMarker:
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    State = HtmlTokenizerState.ScriptDataEscapedState;
                                    EmitCharacterToken(ch); 
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escaped-less-than-sign-state
                    case HtmlTokenizerState.ScriptDataEscapedLessThanSignState:
                        {
                            if (ch == Symbols.Solidus)
                            {
                                _temporaryBuffer.Clear();
                                State = HtmlTokenizerState.ScriptDataEscapedEndTagOpenState;
                            }
                            else if (char.IsLetter(ch))
                            {
                                _temporaryBuffer.Clear();
                                EmitCharacterToken(Symbols.LessThanSign);
                                //State = HtmlTokenizerState.ScriptDoubleEscapeStartState;
                            }
                            else
                            {
                                EmitCharacterToken(Symbols.LessThanSign);
                                ReconsumeIn(HtmlTokenizerState.ScriptDataEscapedState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escaped-end-tag-open-state
                    case HtmlTokenizerState.ScriptDataEscapedEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                token = new HtmlToken();
                                token.BeginEndTag();
                                ReconsumeIn(HtmlTokenizerState.ScriptDataEscapedEndTagNameState);
                            }
                            else
                            {
                                EmitCharacterToken(Symbols.LessThanSign);
                                EmitCharacterToken(Symbols.Solidus);
                                ReconsumeIn(HtmlTokenizerState.ScriptDataEscapedState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-escaped-end-tag-name-state
                    case HtmlTokenizerState.ScriptDataEscapedEndTagNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.Solidus:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        // set state
                                        break;
                                    }
                                    goto default;
                                case Symbols.GreaterThanSign:
                                    if (IsAppropriateEndTag(token))
                                    {
                                        State = HtmlTokenizerState.DataState;
                                        break;
                                    }
                                    goto default;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        token.AppendToName(char.ToLower(ch));
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else if (char.IsLower(ch))
                                    {
                                        token.AppendToName(ch);
                                        _temporaryBuffer.Append(ch);
                                    }
                                    else
                                    {
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        EmitCharacterToken(Symbols.Solidus);
                                        EmitTemporaryBuffer();
                                        ReconsumeIn(HtmlTokenizerState.ScriptDataEscapedState);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-double-escape-start-state
                    case HtmlTokenizerState.ScriptDataDoubleEscapeStartState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                case Symbols.Solidus:
                                case Symbols.GreaterThanSign:
                                    if (_temporaryBuffer.ToString() == "script")
                                    {
                                        State = HtmlTokenizerState.ScriptDataDoubleEscapedState;
                                    }
                                    else
                                    {
                                        State = HtmlTokenizerState.ScriptDataEscapedState;
                                    }
                                    EmitCharacterToken(ch);
                                    break;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        _temporaryBuffer.Append(char.ToLower(ch));
                                        EmitCharacterToken(ch);
                                    }
                                    else if (char.IsLower(ch))
                                    {
                                        _temporaryBuffer.Append(ch);
                                        EmitCharacterToken(ch);
                                    }
                                    else
                                    {
                                        ReconsumeIn(HtmlTokenizerState.ScriptDataEscapedState);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-double-escaped-state
                    case HtmlTokenizerState.ScriptDataDoubleEscapedState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedDashState;
                                    EmitCharacterToken(Symbols.HyphenMinus);
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedLessThanSignState;
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedState;
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-double-escaped-dash-state
                    case HtmlTokenizerState.ScriptDataDoubleEscapedDashState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedDashDashState;
                                    EmitCharacterToken(Symbols.HyphenMinus);
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedLessThanSignState;
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedState;
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedState;
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-double-escaped-dash-dash-state
                    case HtmlTokenizerState.ScriptDataDoubleEscapedDashDashState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    EmitCharacterToken(Symbols.HyphenMinus);
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedLessThanSignState;
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    break;
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.ScriptDataState;
                                    EmitCharacterToken(Symbols.GreaterThanSign);
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedState;
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    State = HtmlTokenizerState.ScriptDataDoubleEscapedState;
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-double-escaped-less-than-sign-state
                    case HtmlTokenizerState.ScriptDataDoubleEscapedLessThanSignState:
                        {
                            if (ch == Symbols.Solidus)
                            {
                                _temporaryBuffer.Clear();
                                State = HtmlTokenizerState.ScriptDataDoubleEscapeEndState;
                                EmitCharacterToken(Symbols.Solidus);
                            }
                            else
                            {
                                ReconsumeIn(HtmlTokenizerState.ScriptDataDoubleEscapedState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#script-data-double-escape-end-state
                    case HtmlTokenizerState.ScriptDataDoubleEscapeEndState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                case Symbols.Solidus:
                                case Symbols.GreaterThanSign:
                                    if (_temporaryBuffer.ToString() == "script")
                                    {
                                        State = HtmlTokenizerState.ScriptDataEscapedState;
                                    }
                                    else
                                    {
                                        State = HtmlTokenizerState.ScriptDataDoubleEscapedState;
                                    }

                                    EmitCharacterToken(ch);
                                    break;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        _temporaryBuffer.Append(char.ToLower(ch));
                                        EmitCharacterToken(ch);
                                    }
                                    else if (char.IsLower(ch))
                                    {
                                        _temporaryBuffer.Append(ch);
                                        EmitCharacterToken(ch);
                                    }
                                    else
                                    {
                                        ReconsumeIn(HtmlTokenizerState.ScriptDataDoubleEscapedState);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#before-attribute-name-state
                    case HtmlTokenizerState.BeforeAttributeNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    break; // ignore it
                                case Symbols.Solidus:
                                case Symbols.GreaterThanSign:
                                case Symbols.EndOfFileMarker:
                                    ReconsumeIn(HtmlTokenizerState.AfterAttributeNameState);
                                    break;
                                case Symbols.EqualsSign:
                                    ParseError();
                                    token.StartNewAttribute();
                                    token.AppendToAttributeName(ch);
                                    State = HtmlTokenizerState.AttributeNameState;
                                    break;
                                default:
                                    token.StartNewAttribute();
                                    ReconsumeIn(HtmlTokenizerState.AttributeNameState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#attribute-name-state
                    case HtmlTokenizerState.AttributeNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                case Symbols.Solidus:
                                case Symbols.GreaterThanSign:
                                case Symbols.EndOfFileMarker:
                                    ReconsumeIn(HtmlTokenizerState.AfterAttributeNameState);
                                    break;
                                case Symbols.EqualsSign:
                                    State = HtmlTokenizerState.BeforeAttributeValueState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    token.AppendToAttributeName(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.QuotationMark:
                                case Symbols.Apostrophe:
                                case Symbols.LessThanSign:
                                    ParseError();
                                    goto default;
                                default:
                                    token.AppendToAttributeName(char.ToLower(ch));
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#after-attribute-name-state
                    case HtmlTokenizerState.AfterAttributeNameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    break; // ignore it
                                case Symbols.Solidus:
                                    break;
                                case Symbols.EqualsSign:
                                    State = HtmlTokenizerState.BeforeAttributeValueState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.StartNewAttribute();
                                    ReconsumeIn(HtmlTokenizerState.AttributeNameState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#before-attribute-value-state
                    case HtmlTokenizerState.BeforeAttributeValueState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    break; // ignore it
                                case Symbols.QuotationMark:
                                    State = HtmlTokenizerState.AttributeValueDoubleQuotedState;
                                    break;
                                case Symbols.Apostrophe:
                                    State = HtmlTokenizerState.AttributeValueSingleQuotedState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    ParseError();
                                    goto default;
                                default:
                                    ReconsumeIn(HtmlTokenizerState.AttributeValueUnquotedState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#attribute-value-double-quoted-state
                    case HtmlTokenizerState.AttributeValueDoubleQuotedState:
                        {
                            switch (ch)
                            {
                                case Symbols.QuotationMark:
                                    State = HtmlTokenizerState.AfterAttributeValueQuotedState;
                                    break;
                                case Symbols.Ampersand:
                                    returnState = HtmlTokenizerState.AttributeValueDoubleQuotedState;
                                    //State = HtmlTokenizerState.CharacterReference;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    token.AppendToAttributeValue(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToAttributeValue(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#attribute-value-single-quoted-state
                    case HtmlTokenizerState.AttributeValueSingleQuotedState:
                        {
                            switch (ch)
                            {
                                case Symbols.Apostrophe:
                                    State = HtmlTokenizerState.AfterAttributeValueQuotedState;
                                    break;
                                case Symbols.Ampersand:
                                    returnState = HtmlTokenizerState.AttributeValueSingleQuotedState;
                                    //State = HtmlTokenizerState.CharacterReferenceState;
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    token.AppendToAttributeValue(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToAttributeValue(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#attribute-value-unquoted-state
                    case HtmlTokenizerState.AttributeValueUnquotedState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    State = HtmlTokenizerState.BeforeAttributeNameState;
                                    break;
                                case Symbols.Ampersand:
                                    returnState = HtmlTokenizerState.AttributeValueUnquotedState;
                                    //State = HtmlTokenizerState.CharacterReferenceState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    token.AppendToAttributeValue(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.QuotationMark:
                                case Symbols.Apostrophe:
                                case Symbols.LessThanSign:
                                case Symbols.EqualsSign:
                                case Symbols.GraveAccent:
                                    ParseError();
                                    goto default;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToAttributeValue(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#after-attribute-value-quoted-state
                    case HtmlTokenizerState.AfterAttributeValueQuotedState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    State = HtmlTokenizerState.BeforeAttributeNameState;
                                    break;
                                case Symbols.Solidus:
                                    State = HtmlTokenizerState.SelfClosingStartTagState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    ParseError();
                                    ReconsumeIn(HtmlTokenizerState.BeforeAttributeNameState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#self-closing-start-tag-state
                    case HtmlTokenizerState.SelfClosingStartTagState:
                        {
                            switch (ch)
                            {
                                case Symbols.GreaterThanSign:
                                    token.IsSelfClosing = true;
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    ParseError();
                                    ReconsumeIn(HtmlTokenizerState.BeforeAttributeNameState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#bogus-comment-state
                    case HtmlTokenizerState.BogusCommentState:
                        {
                            switch (ch)
                            {
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                case Symbols.Null:
                                    token.AppendToComment(Symbols.ReplacementCharacter);
                                    break;
                                default:
                                    token.AppendToComment(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#markup-declaration-open-state
                    case HtmlTokenizerState.MarkupDeclarationOpenState:
                        {
                            // TODO: Add peek ahead to tokenizer base class
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-start-state
                    case HtmlTokenizerState.CommentStartState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    State = HtmlTokenizerState.CommentStartDashState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    ParseError();
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                default:
                                    ReconsumeIn(HtmlTokenizerState.CommentState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-start-dash-state
                    case HtmlTokenizerState.CommentStartDashState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    break;
                                case Symbols.GreaterThanSign:
                                    ParseError();
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToComment(ch);
                                    ReconsumeIn(HtmlTokenizerState.CommentState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-state
                    case HtmlTokenizerState.CommentState:
                        {
                            switch (ch)
                            {
                                case Symbols.LessThanSign:
                                    token.AppendToComment(ch);
                                    State = HtmlTokenizerState.CommentLessThanSignState;
                                    break;
                                case Symbols.HyphenMinus:
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    token.AppendToComment(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToComment(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-less-than-sign-state
                    case HtmlTokenizerState.CommentLessThanSignState:
                        {
                            switch (ch)
                            {
                                case Symbols.ExclamationMark:
                                    token.AppendToComment(ch);
                                    State = HtmlTokenizerState.CommentLessThanSignBangState;
                                    break;
                                case Symbols.LessThanSign:
                                    token.AppendToComment(ch);
                                    break;
                                default:
                                    ReconsumeIn(HtmlTokenizerState.CommentState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-less-than-sign-bang-state
                    case HtmlTokenizerState.CommentLessThanSignBangState:
                        {
                            if (ch == Symbols.HyphenMinus)
                            {
                                State = HtmlTokenizerState.CommentLessThanSignBangDashState;
                            }
                            else
                            {
                                ReconsumeIn(HtmlTokenizerState.CommentState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-less-than-sign-bang-dash-state
                    case HtmlTokenizerState.CommentLessThanSignBangDashState:
                        {
                            if (ch == Symbols.HyphenMinus)
                            {
                                State = HtmlTokenizerState.CommentLessThanSignBangDashDashState;
                            }
                            else
                            {
                                ReconsumeIn(HtmlTokenizerState.CommentEndDashState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-less-than-sign-bang-dash-dash-state
                    case HtmlTokenizerState.CommentLessThanSignBangDashDashState:
                        {
                            if (ch == Symbols.GreaterThanSign || ch == Symbols.EndOfFileMarker)
                            {
                                ReconsumeIn(HtmlTokenizerState.CommentEndState);
                            }
                            else
                            {
                                ParseError();
                                ReconsumeIn(HtmlTokenizerState.CommentEndState);
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-end-dash-state
                    case HtmlTokenizerState.CommentEndDashState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    State = HtmlTokenizerState.CommentEndState;
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    ReconsumeIn(HtmlTokenizerState.CommentState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-end-state
                    case HtmlTokenizerState.CommentEndState:
                        {
                            switch (ch)
                            {
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.ExclamationMark:
                                    State = HtmlTokenizerState.CommentEndBangState;
                                    break;
                                case Symbols.HyphenMinus:
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    ReconsumeIn(HtmlTokenizerState.CommentState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#comment-end-bang-state
                    case HtmlTokenizerState.CommentEndBangState:
                        {
                            switch (ch)
                            {
                                case Symbols.HyphenMinus:
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    token.AppendToComment(Symbols.ExclamationMark);
                                    State = HtmlTokenizerState.CommentEndDashState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    ParseError();
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    token.AppendToComment(Symbols.HyphenMinus);
                                    token.AppendToComment(Symbols.ExclamationMark);
                                    State = HtmlTokenizerState.CommentState;
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#doctype-state
                    case HtmlTokenizerState.DOCTYPEState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    State = HtmlTokenizerState.BeforeDOCTYPENameState;
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    token = new HtmlToken();
                                    token.BeginDocType();
                                    token.ForceQuirks = true;
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    ParseError();
                                    ReconsumeIn(HtmlTokenizerState.BeforeDOCTYPENameState);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#before-doctype-name-state
                    case HtmlTokenizerState.BeforeDOCTYPENameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    break; // ignore it
                                case Symbols.Null:
                                    ParseError();
                                    token = new HtmlToken();
                                    token.BeginDocType();
                                    token.AppendToName(Symbols.ReplacementCharacter);
                                    State = HtmlTokenizerState.DOCTYPENameState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    ParseError();
                                    token = new HtmlToken();
                                    token.BeginDocType();
                                    token.ForceQuirks = true;
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    token = new HtmlToken();
                                    token.BeginDocType();
                                    token.ForceQuirks = true;
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    token = new HtmlToken();
                                    token.BeginDocType();
                                    if (char.IsUpper(ch))
                                    {
                                        token.AppendToName(char.ToLower(ch));
                                    }
                                    else
                                    {
                                        token.AppendToName(ch);
                                    }
                                    State = HtmlTokenizerState.DOCTYPENameState;
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#doctype-name-state
                    case HtmlTokenizerState.DOCTYPENameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    State = HtmlTokenizerState.AfterDOCTYPENameState;
                                    break;
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.Null:
                                    ParseError();
                                    token.AppendToName(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    token.ForceQuirks = true;
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    if (char.IsUpper(ch))
                                    {
                                        token.AppendToName(char.ToLower(ch));
                                    }
                                    else
                                    {
                                        token.AppendToName(ch);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://www.w3.org/TR/html5/syntax.html#after-doctype-name-state
                    case HtmlTokenizerState.AfterDOCTYPENameState:
                        {
                            switch (ch)
                            {
                                case Symbols.CharacterTabulation:
                                case Symbols.LineFeed:
                                case Symbols.FormFeed:
                                case Symbols.Space:
                                    break; // ignore it
                                case Symbols.GreaterThanSign:
                                    State = HtmlTokenizerState.DataState;
                                    EmitToken(token);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError();
                                    token.ForceQuirks = true; // TODO: this will throw on next call
                                    EmitToken(token);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    // TODO: String Lookahead
                                    break;
                            }
                            break;
                        }
                }
            }

            return _tokens.Dequeue();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EmitToken(HtmlToken token)
        {
            if (token.Type == HtmlToken.TokenType.START_TAG)
            {
                _lastEmittedStartTag = token.Name;
            }

            _tokens.Enqueue(token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ch"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EmitCharacterToken(char ch)
        {
            HtmlToken token = new HtmlToken();

            token.MakeCharacter(ch);

            _tokens.Enqueue(token);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EmitEndOfFileToken()
        {
            HtmlToken token = new HtmlToken();

            token.MakeEndOfFile();

            _tokens.Enqueue(token);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EmitTemporaryBuffer()
        {
            foreach (char c in _temporaryBuffer.ToString())
            {
                EmitCharacterToken(c);
            }

            _temporaryBuffer.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsAppropriateEndTag(HtmlToken token)
        {
            return token.Type == HtmlToken.TokenType.END_TAG &&
                _lastEmittedStartTag == token.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ParseError()
        {
            // TODO: do something here
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ReconsumeIn(HtmlTokenizerState state)
        {
            Back();
            State = state;
        }
    }
}
