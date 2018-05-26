namespace Redc.Browser.Html.Parser
{
    /// <summary>
    /// Dedicated codes for parse errors
    /// </summary>
    internal enum HtmlParseErrorCode
    {
        /// <summary>
        /// 
        /// </summary>
        AbruptClosingOfEmptyComment,

        /// <summary>
        /// 
        /// </summary>
        AbruptDoctypePublicIdentifier,

        /// <summary>
        /// 
        /// </summary>
        AbruptDoctypeSystemIdentifier,
        
        /// <summary>
        /// 
        /// </summary>
        AbsenceOfDigitsInNumericCharacterReference,

        /// <summary>
        /// 
        /// </summary>
        CDataInHtmlContent,

        /// <summary>
        /// 
        /// </summary>
        CharacterReferenceOutsideUnicodeRange,

        /// <summary>
        /// 
        /// </summary>
        ControlCharacterInInputStream,

        /// <summary>
        /// 
        /// </summary>
        EndTagWithAttributes,

        /// <summary>
        /// 
        /// </summary>
        DuplicateAttribute,

        /// <summary>
        /// 
        /// </summary>
        EndTagWithTrailingSolidus,

        /// <summary>
        /// 
        /// </summary>
        EofBeforeTagName,

        /// <summary>
        /// 
        /// </summary>
        EofInCData,

        /// <summary>
        /// 
        /// </summary>
        EofInComment,

        /// <summary>
        /// 
        /// </summary>
        EofInDoctype,

        /// <summary>
        /// 
        /// </summary>
        EofInScriptHtmlCommentLikeText,

        /// <summary>
        /// 
        /// </summary>
        EofInTag,

        /// <summary>
        /// 
        /// </summary>
        IncorrectlyClosedComment,

        /// <summary>
        /// 
        /// </summary>
        IncorrectlyOpenedComment,

        /// <summary>
        /// 
        /// </summary>
        InvalidCharacterSequenceAfterDoctypeName,

        /// <summary>
        /// 
        /// </summary>
        InvalidFirstCharacterOfTagName,

        /// <summary>
        /// 
        /// </summary>
        MissingAttributeValue,

        /// <summary>
        /// 
        /// </summary>
        MissingDoctypeName,

        /// <summary>
        /// 
        /// </summary>
        MissingDoctypePublicIdentifier,

        /// <summary>
        /// 
        /// </summary>
        MissingDoctypeSystemIdentifier,

        /// <summary>
        /// 
        /// </summary>
        MissingEndTagName,

        /// <summary>
        /// 
        /// </summary>
        MissingQuoteBeforeDoctypePublicIdentifier,

        /// <summary>
        /// 
        /// </summary>
        MissingQuoteBeforeDoctypeSystemIdentifier,

        /// <summary>
        /// 
        /// </summary>
        MissingSemicolonAfterCharacterReference,

        /// <summary>
        /// 
        /// </summary>
        MissingWhitespaceAfterDoctypePublicKeyword,

        /// <summary>
        /// 
        /// </summary>
        MissingWhitespaceAfterDoctypeSystemKeyword,

        /// <summary>
        /// 
        /// </summary>
        MissingWhitespaceBeforeDoctypeName,

        /// <summary>
        /// 
        /// </summary>
        MissingWhitespaceBEtweenAttributes,

        /// <summary>
        /// 
        /// </summary>
        MissingWhitespaceBetweenDoctypePublicAndSystemIdentifiers,

        /// <summary>
        /// 
        /// </summary>
        NestedComment,

        /// <summary>
        /// 
        /// </summary>
        NoncharacterCharacterReference,

        /// <summary>
        /// 
        /// </summary>
        NoncharacterInInputStream,

        /// <summary>
        /// 
        /// </summary>
        NonVoidHtmlElementStartTagWithTrailingSolidus,

        /// <summary>
        /// 
        /// </summary>
        NullCharacterReference,

        /// <summary>
        /// 
        /// </summary>
        SurrogateCharacterReference,

        /// <summary>
        /// 
        /// </summary>
        SurrogateInInputStream,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedCharacterAfterDoctypeSystemIdentifier,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedCharacterInAttributeName,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedCharacterInUnquotedAttributeValue,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedEqualsSignBeforeAttributName,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedNullCharacter,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedQuestionMarkInsteadOfTagName,

        /// <summary>
        /// 
        /// </summary>
        UnexpectedSolidusInTag,

        /// <summary>
        /// 
        /// </summary>
        UnknownNamedCharacterReference
    }
}
