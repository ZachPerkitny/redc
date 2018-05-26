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
        private HtmlTokenizerState _returnState;

        private HtmlToken _token;
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
            while (true)
            {
                // if a token was emitted last loop,
                // or there are any left over from the
                // last call, emit it
                if (_tokens.Count > 0)
                {
                    return _tokens.Dequeue();
                }

                char ch = Consume();

                switch (State)
                {
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#data-state
                    case HtmlTokenizerState.DataState:
                        {
                            switch (ch)
                            {
                                case Symbols.Ampersand:
                                    _returnState = HtmlTokenizerState.DataState;
                                    State = HtmlTokenizerState.CharcterReferenceInDataState;
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.TagOpenState;
                                    break;
                                case Symbols.Null:
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
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
                    case HtmlTokenizerState.CharcterReferenceInDataState:
                        {
                            State = HtmlTokenizerState.DataState;
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rcdata-state
                    case HtmlTokenizerState.RCDATAState:
                        {
                            switch (ch)
                            {
                                case Symbols.Ampersand:
                                    State = HtmlTokenizerState.CharacterReferenceInRCDATAState;
                                    break;
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.RCDATALessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
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
                    case HtmlTokenizerState.CharacterReferenceInRCDATAState:
                        {
                            State = HtmlTokenizerState.RCDATAState;
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rawtext-state
                    case HtmlTokenizerState.RAWTEXTState:
                        {
                            switch (ch)
                            {
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.RAWTEXTLessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-state
                    case HtmlTokenizerState.ScriptDataState:
                        {
                            switch (ch)
                            {
                                case Symbols.LessThanSign:
                                    State = HtmlTokenizerState.ScriptDataLessThanSignState;
                                    break;
                                case Symbols.Null:
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#plaintext-state
                    case HtmlTokenizerState.PLAINTEXTState:
                        {
                            switch (ch)
                            {
                                case Symbols.Null:
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#tag-open-state
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
                                    ParseError(HtmlParseErrorCode.UnexpectedQuestionMarkInsteadOfTagName);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError(HtmlParseErrorCode.EofBeforeTagName);
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    if (char.IsLetter(ch))
                                    {
                                        _token = new HtmlToken();
                                        _token.BeginStartTag();
                                        ReconsumeIn(HtmlTokenizerState.TagNameState);
                                    }
                                    else
                                    {
                                        ParseError(HtmlParseErrorCode.InvalidFirstCharacterOfTagName);
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        ReconsumeIn(HtmlTokenizerState.DataState);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#end-tag-open-state
                    case HtmlTokenizerState.EndTagOpenState:
                        {
                            switch (ch)
                            {
                                case Symbols.GreaterThanSign:
                                    ParseError(HtmlParseErrorCode.MissingEndTagName);
                                    State = HtmlTokenizerState.DataState;
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError(HtmlParseErrorCode.EofBeforeTagName);
                                    EmitCharacterToken(Symbols.LessThanSign);
                                    EmitCharacterToken(Symbols.Solidus);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    if (char.IsLetter(ch))
                                    {
                                        _token = new HtmlToken();
                                        _token.BeginEndTag();

                                        ReconsumeIn(HtmlTokenizerState.TagNameState);
                                    }
                                    else
                                    {
                                        ParseError(HtmlParseErrorCode.InvalidFirstCharacterOfTagName);
                                    }
                                    break;
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#tag-name-state
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
                                    EmitToken();
                                    break;
                                case Symbols.Null:
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
                                    _token.AppendToName(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError(HtmlParseErrorCode.EofInTag);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    _token.AppendToName(char.ToLower(ch));
                                    break;
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rcdata-less-than-sign-state
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rcdata-end-tag-open-state
                    case HtmlTokenizerState.RCDATAEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                _token = new HtmlToken();
                                _token.BeginEndTag();
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rcdata-end-tag-name-state
                    case HtmlTokenizerState.RCDataEndTagNameState:
                        {
                            if (char.IsLetter(ch))
                            {
                                _token.AppendToName(char.ToLower(ch));
                                _temporaryBuffer.Append(ch);
                            }
                            else
                            {
                                switch (ch)
                                {
                                    case Symbols.CharacterTabulation:
                                    case Symbols.LineFeed:
                                    case Symbols.FormFeed:
                                    case Symbols.Space:
                                        if (IsAppropriateEndTag())
                                        {
                                            // set state
                                            break;
                                        }
                                        goto default;
                                    case Symbols.Solidus:
                                        if (IsAppropriateEndTag())
                                        {
                                            // set state
                                            break;
                                        }
                                        goto default;
                                    case Symbols.GreaterThanSign:
                                        if (IsAppropriateEndTag())
                                        {
                                            State = HtmlTokenizerState.DataState;
                                            break;
                                        }
                                        goto default;
                                    default:
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        EmitCharacterToken(Symbols.Solidus);
                                        EmitTemporaryBuffer();
                                        ReconsumeIn(HtmlTokenizerState.RCDATAState);
                                        break;
                                }
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rawtext-less-than-sign-state
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rawtext-end-tag-open-state
                    case HtmlTokenizerState.RAWTEXTEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                _token = new HtmlToken();
                                _token.BeginEndTag();
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#rawtext-end-tag-name-state
                    case HtmlTokenizerState.RAWTextEndTagNameState:
                        {
                            if (char.IsLetter(ch))
                            {
                                _token.AppendToName(char.ToLower(ch));
                                _temporaryBuffer.Append(ch);
                            }
                            else
                            {
                                switch (ch)
                                {
                                    case Symbols.CharacterTabulation:
                                    case Symbols.LineFeed:
                                    case Symbols.FormFeed:
                                    case Symbols.Space:
                                        if (IsAppropriateEndTag())
                                        {
                                            // set state
                                            break;
                                        }
                                        goto default;
                                    case Symbols.Solidus:
                                        if (IsAppropriateEndTag())
                                        {
                                            // set state
                                            break;
                                        }
                                        goto default;
                                    case Symbols.GreaterThanSign:
                                        if (IsAppropriateEndTag())
                                        {
                                            State = HtmlTokenizerState.DataState;
                                            break;
                                        }
                                        goto default;
                                    default:
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        EmitCharacterToken(Symbols.Solidus);
                                        EmitTemporaryBuffer();
                                        ReconsumeIn(HtmlTokenizerState.RAWTEXTState);
                                        break;
                                }
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-less-than-sign-state
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-end-tag-open-state
                    case HtmlTokenizerState.ScriptDataEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                _token = new HtmlToken();
                                _token.BeginEndTag();
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-end-tag-name-state
                    case HtmlTokenizerState.ScriptDataEndTagNameState:
                        {
                            if (char.IsLetter(ch))
                            {
                                _token.AppendToName(char.ToLower(ch));
                                _temporaryBuffer.Append(ch);
                            }
                            else
                            {
                                switch (ch)
                                {
                                    case Symbols.CharacterTabulation:
                                    case Symbols.LineFeed:
                                    case Symbols.FormFeed:
                                    case Symbols.Space:
                                        if (IsAppropriateEndTag())
                                        {
                                            // set state
                                            break;
                                        }
                                        goto default;
                                    case Symbols.Solidus:
                                        if (IsAppropriateEndTag())
                                        {
                                            // set state
                                            break;
                                        }
                                        goto default;
                                    case Symbols.GreaterThanSign:
                                        if (IsAppropriateEndTag())
                                        {
                                            State = HtmlTokenizerState.DataState;
                                            break;
                                        }
                                        goto default;
                                    default:
                                        EmitCharacterToken(Symbols.LessThanSign);
                                        EmitCharacterToken(Symbols.Solidus);
                                        EmitTemporaryBuffer();
                                        ReconsumeIn(HtmlTokenizerState.ScriptDataState);
                                        break;
                                }
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-escape-start-state
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-escape-start-dash-state
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-escaped-state
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
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError(HtmlParseErrorCode.EofInScriptHtmlCommentLikeText);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-escaped-dash-state
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
                                    ParseError(HtmlParseErrorCode.UnexpectedNullCharacter);
                                    State = HtmlTokenizerState.ScriptDataEscapedState;
                                    EmitCharacterToken(Symbols.ReplacementCharacter);
                                    break;
                                case Symbols.EndOfFileMarker:
                                    ParseError(HtmlParseErrorCode.EofInScriptHtmlCommentLikeText);
                                    EmitEndOfFileToken();
                                    break;
                                default:
                                    State = HtmlTokenizerState.ScriptDataEscapedState;
                                    EmitCharacterToken(ch);
                                    break;
                            }
                            break;
                        }
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-escaped-dash-dash-state
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-escaped-less-than-sign-state
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
                    // Reference: https://html.spec.whatwg.org/multipage/parsing.html#script-data-escaped-end-tag-open-state
                    case HtmlTokenizerState.ScriptDataEscapedEndTagOpenState:
                        {
                            if (char.IsLetter(ch))
                            {
                                _token = new HtmlToken();
                                _token.BeginEndTag();
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
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void EmitToken()
        {
            if (_token.Type == HtmlToken.TokenType.START_TAG)
            {
                _lastEmittedStartTag = _token.Name;
            }

            _tokens.Enqueue(_token);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
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
        /// <returns></returns>
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
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsAppropriateEndTag()
        {
            return _token.Type == HtmlToken.TokenType.END_TAG &&
                _lastEmittedStartTag == _token.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void ParseError(HtmlParseErrorCode code)
        {

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
