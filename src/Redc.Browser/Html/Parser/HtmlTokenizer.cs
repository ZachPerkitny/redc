using System.Runtime.CompilerServices;
using System.Text;
using Redc.Browser.Utils;

namespace Redc.Browser.Html.Parser
{
    internal class HtmlTokenizer
    {
        private readonly string _source;
        private int _index;

        private readonly StringBuilder _temporaryBuffer;

        private HtmlToken _token;
        private string _lastEmittedStartTag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        public HtmlTokenizer(string source)
        {
            _source = source;
            _index = 0;

            State = HtmlTokenizerState.DataState;

            _temporaryBuffer = new StringBuilder();
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
            _token = new HtmlToken();

            switch (State)
            {
                case HtmlTokenizerState.DataState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.Ampersand:
                                ConsumeAndSetState(HtmlTokenizerState.CharcterReferenceInDataState);
                                break;
                            case Symbols.LessThanSign:
                                ConsumeAndSetState(HtmlTokenizerState.TagOpenState);
                                break;
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                ConsumeAndAppendCurrentCharacter();
                                break;
                            
                        }
                        break;
                    }
                case HtmlTokenizerState.CharcterReferenceInDataState:
                    {
                        State = HtmlTokenizerState.DataState;
                        break;
                    }
                case HtmlTokenizerState.RCDATAState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.Ampersand:
                                ConsumeAndSetState(HtmlTokenizerState.CharacterReferenceInRCDATAState);
                                break;
                            case Symbols.LessThanSign:
                                break;
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.CharacterReferenceInRCDATAState:
                    {
                        State = HtmlTokenizerState.RCDATAState;
                        break;
                    }
                case HtmlTokenizerState.RAWTEXTState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.LessThanSign:
                                break;
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.LessThanSign:
                                break;
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.PLAINTEXTState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.TagOpenState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.ExclamationMark:
                                break;
                            case Symbols.Solidus:
                                break;
                            case Symbols.QuestionMark:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                if (char.IsLetter(NextCharacterInput))
                                {
                                    _token.BeginStartTag(NextCharacterInput);

                                }
                                else
                                {
                                    State = HtmlTokenizerState.DataState;
                                }
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.EndTagOpenState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.GreaterThanSign:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                if (char.IsLetter(NextCharacterInput))
                                {
                                    _token.BeginEndTag(NextCharacterInput);

                                }
                                else
                                {

                                }
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.TagNameState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.CharacterTabulation:
                            case Symbols.LineFeed:
                            case Symbols.FormFeed:
                            case Symbols.Space:
                                break;
                            case Symbols.Solidus:
                                break;
                            case Symbols.GreaterThanSign:
                                return EmitAndSetState(HtmlTokenizerState.DataState);
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                ConsumeAndAppendCurrentName();
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.RCDATALessThanSignState:
                    {
                        if (NextCharacterInput == Symbols.Solidus)
                        {
                            _temporaryBuffer.Clear();
                            State = HtmlTokenizerState.RCDATAEndTagOpenState;
                        }
                        else
                        {
                            AppendCharacter(Symbols.LessThanSign);
                            State = HtmlTokenizerState.RCDATAState;
                        }
                        break;
                    }
                case HtmlTokenizerState.RCDATAEndTagOpenState:
                    {
                        if (char.IsLetter(NextCharacterInput))
                        {
                            _token.BeginEndTag(NextCharacterInput);
                            State = HtmlTokenizerState.RCDataEndTagNameState;
                        }
                        else
                        {
                            AppendCharacter(Symbols.LessThanSign);
                            AppendCharacter(Symbols.Solidus);
                            State = HtmlTokenizerState.RCDATAState;
                        }
                        break;
                    }
                case HtmlTokenizerState.RCDataEndTagNameState:
                    {
                        if (char.IsLetter(NextCharacterInput))
                        {
                            _temporaryBuffer.Append(NextCharacterInput);
                            ConsumeAndAppendCurrentName();
                        }
                        else
                        {
                            switch (NextCharacterInput)
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
                                    AppendCharacter(Symbols.LessThanSign);
                                    AppendCharacter(Symbols.Solidus);
                                    _token.AppendToCharacter(_temporaryBuffer.ToString());
                                    _temporaryBuffer.Clear();
                                    State = HtmlTokenizerState.RCDATAState;
                                    break;
                            }
                        }           
                        break;
                    }
                case HtmlTokenizerState.RAWTEXTLessThanSignState:
                    {
                        if (NextCharacterInput == Symbols.Solidus)
                        {
                            _temporaryBuffer.Clear();
                            ConsumeAndSetState(HtmlTokenizerState.RAWTEXTEndTagOpenState);
                        }
                        else
                        {
                            AppendCharacter(Symbols.LessThanSign);
                            State = HtmlTokenizerState.RAWTEXTState;
                        }
                        break;
                    }
                case HtmlTokenizerState.RAWTEXTEndTagOpenState:
                    {
                        if (char.IsLower(NextCharacterInput))
                        {
                            _token.BeginEndTag(NextCharacterInput);
                            ConsumeAndSetState(HtmlTokenizerState.RAWTextEndTagNameState);
                        }
                        else
                        {
                            AppendCharacter(Symbols.LessThanSign);
                            AppendCharacter(Symbols.Solidus);
                            State = HtmlTokenizerState.RAWTEXTState;
                        }
                        break;
                    }
                case HtmlTokenizerState.RAWTextEndTagNameState:
                    {
                        if (char.IsLetter(NextCharacterInput))
                        {
                            _temporaryBuffer.Append(NextCharacterInput);
                            ConsumeAndAppendCurrentName();
                        }
                        else
                        {
                            switch (NextCharacterInput)
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
                                    AppendCharacter(Symbols.LessThanSign);
                                    AppendCharacter(Symbols.Solidus);
                                    _token.AppendToCharacter(_temporaryBuffer.ToString());
                                    _temporaryBuffer.Clear();
                                    State = HtmlTokenizerState.RAWTEXTState;
                                    break;
                            }
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataLessThanSignState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.Solidus:
                                _temporaryBuffer.Clear();
                                ConsumeAndSetState(HtmlTokenizerState.ScriptDataEndTagOpenState);
                                break;
                            case Symbols.ExclamationMark:
                                AppendCharacter(Symbols.LessThanSign);
                                AppendCharacter(Symbols.ExclamationMark);
                                //State = 
                                break;
                            default:
                                AppendCharacter(Symbols.LessThanSign);
                                State = HtmlTokenizerState.ScriptDataState;
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEndTagOpenState:
                    {
                        if (char.IsLetter(NextCharacterInput))
                        {
                            _token.BeginEndTag(NextCharacterInput);
                            ConsumeAndSetState(HtmlTokenizerState.ScriptDataEndTagNameState);
                        }
                        else
                        {
                            AppendCharacter(Symbols.LessThanSign);
                            AppendCharacter(Symbols.Solidus);
                            State = HtmlTokenizerState.ScriptDataState;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEndTagNameState:
                    {
                        if (char.IsLetter(NextCharacterInput))
                        {
                            _temporaryBuffer.Append(NextCharacterInput);
                            ConsumeAndAppendCurrentName();
                        }
                        else
                        {
                            switch (NextCharacterInput)
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
                                    AppendCharacter(Symbols.LessThanSign);
                                    AppendCharacter(Symbols.Solidus);
                                    _token.AppendToCharacter(_temporaryBuffer.ToString());
                                    _temporaryBuffer.Clear();
                                    State = HtmlTokenizerState.ScriptDataState;
                                    break;
                            }
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEscapeStartState:
                    {
                        if (NextCharacterInput == Symbols.HyphenMinus)
                        {
                            ConsumeAndAppendCurrentCharacter();
                            State = HtmlTokenizerState.ScriptDataEscapeStartDashState;
                        }
                        else
                        {
                            State = HtmlTokenizerState.ScriptDataState;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEscapeStartDashState:
                    {
                        if (NextCharacterInput == Symbols.HyphenMinus)
                        {
                            ConsumeAndAppendCurrentCharacter();
                        }
                        else
                        {
                            State = HtmlTokenizerState.ScriptDataState;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEscapedState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.HyphenMinus:
                                ConsumeAndAppendCurrentCharacter();
                                State = HtmlTokenizerState.ScriptDataEscapedDashState;
                                break;
                            case Symbols.LessThanSign:
                                ConsumeAndSetState(HtmlTokenizerState.ScriptDataEscapedLessThanSignState);
                                break;
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                ConsumeAndAppendCurrentCharacter();
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEscapedDashState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.HyphenMinus:
                                ConsumeAndAppendCurrentCharacter();
                                //State = HtmlTokenizerState
                                break;
                            case Symbols.LessThanSign:
                                ConsumeAndSetState(HtmlTokenizerState.ScriptDataEscapedLessThanSignState);
                                break;
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                ConsumeAndAppendCurrentCharacter();
                                State = HtmlTokenizerState.ScriptDataEscapedState;
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEscapedDashDashState:
                    {
                        switch (NextCharacterInput)
                        {
                            case Symbols.HyphenMinus:
                                ConsumeAndAppendCurrentCharacter();
                                break;
                            case Symbols.LessThanSign:
                                ConsumeAndSetState(HtmlTokenizerState.ScriptDataEscapedLessThanSignState);
                                break;
                            case Symbols.GreaterThanSign:
                                ConsumeAndAppendCurrentCharacter();
                                State = HtmlTokenizerState.ScriptDataState;
                                break;
                            case Symbols.Null:
                                break;
                            case Symbols.EndOfFileMarker:
                                break;
                            default:
                                ConsumeAndAppendCurrentCharacter();
                                State = HtmlTokenizerState.ScriptDataEscapedState;
                                break;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEscapedLessThanSignState:
                    {
                        if (NextCharacterInput == Symbols.Solidus)
                        {
                            _temporaryBuffer.Clear();
                            ConsumeAndSetState(HtmlTokenizerState.ScriptDataEscapedEndTagOpenState);
                        }
                        else if (char.IsLetter(NextCharacterInput))
                        {
                            _temporaryBuffer.Clear();
                            AppendCharacter(Symbols.LessThanSign);
                            //State = HtmlTokenizerState.ScriptDoubleEscapeStartState;
                        }
                        else
                        {
                            AppendCharacter(Symbols.LessThanSign);
                            State = HtmlTokenizerState.ScriptDataEscapedState;
                        }
                        break;
                    }
                case HtmlTokenizerState.ScriptDataEscapedEndTagOpenState:
                    {
                        if (char.IsLetter(NextCharacterInput))
                        {
                            _token.BeginEndTag(NextCharacterInput);
                            ConsumeAndSetState(HtmlTokenizerState.ScriptDataEscapedEndTagNameState);
                        }
                        else
                        {
                            AppendCharacter(Symbols.LessThanSign);
                            AppendCharacter(Symbols.Solidus);
                            State = HtmlTokenizerState.ScriptDataEscapedState;
                        }
                        break;
                    }
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary> 
        private char CurrentCharacterInput
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return (_index < _source.Length) ? _source[_index] : Symbols.EndOfFileMarker;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private char NextCharacterInput
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get
            {
                return (_index + 1 < _source.Length) ? _source[_index + 1] : Symbols.EndOfFileMarker;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void AppendCharacter(char c)
        {
            _token.EnsureCharacter();
            _token.AppendToCharacter(c);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ConsumeAndAppendCurrentCharacter()
        {
            _token.EnsureCharacter();

            _index++;
            _token.AppendToCharacter(CurrentCharacterInput);
        }

        /// <summary>
        /// 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ConsumeAndAppendCurrentName()
        {
            _index++;
            _token.AppendToName(char.ToLower(CurrentCharacterInput));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void ConsumeAndSetState(HtmlTokenizerState state)
        {
            _index++;
            State = state;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private HtmlToken EmitAndSetState(HtmlTokenizerState state)
        {
            if (_token.Type == HtmlToken.HtmlTokenType.START_TAG)
            {
                _lastEmittedStartTag = _token.Name;
            }

            State = state;

            return _token;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private bool IsAppropriateEndTag()
        {
            return _token.Type == HtmlToken.HtmlTokenType.END_TAG &&
                _lastEmittedStartTag == _token.Name;
        }
    }
}
