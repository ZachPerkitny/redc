using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Redc.Browser.Html.Parser
{
    internal class HtmlToken
    {
        public enum TokenType
        {
            UNITIALIZED,
            DOCTYPE,
            START_TAG,
            END_TAG,
            COMMENT,
            CHARACTER,
            EOF
        }

        #region Fields

        private StringBuilder _data;
        private DoctypeData _doctypeData;
        private TagData _tagData;

        #endregion

        #region Ctor

        /// <summary>
        /// 
        /// </summary>
        public HtmlToken()
        {
            _data = new StringBuilder();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public TokenType Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUninitialized
        {
            get { return Type == TokenType.UNITIALIZED; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Data
        {
            get { return _data.ToString(); }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get
            {
                Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG || Type == TokenType.DOCTYPE);
                return _data.ToString();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool ForceQuirks
        {
            get
            {
                Contract.Requires(Type == TokenType.DOCTYPE);
                return _doctypeData.ForceQuirks;
            }
            set
            {
                Contract.Requires(Type == TokenType.DOCTYPE);
                _doctypeData.ForceQuirks = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public IEnumerable<Attribute> Attributes
        {
            get
            {
                Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG);
                return _tagData.Attributes.AsReadOnly();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSelfClosing
        {
            get
            {
                Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG);
                return _tagData.IsSelfClosing;
            }
            set
            {
                Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG);
                _tagData.IsSelfClosing = value;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToName(char c)
        {
            Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG || Type == TokenType.DOCTYPE);
            _data.Append(c);
        }

        /// <summary>
        /// 
        /// </summary>
        public void MakeCharacter(char c)
        {
            Contract.Requires(IsUninitialized);
            Type = TokenType.CHARACTER;

            _data.Append(c);
        }

        /// <summary>
        /// 
        /// </summary>
        public void MakeEndOfFile()
        {
            Contract.Requires(IsUninitialized);
            Type = TokenType.EOF;
        }

        #region DocType Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void BeginDocType(char c)
        {
            Contract.Requires(IsUninitialized);
            Type = TokenType.DOCTYPE;
            _doctypeData = new DoctypeData();

            _data.Append(c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AddCharacterToPublicIdentifier(char c)
        {
            Contract.Requires(Type == TokenType.DOCTYPE);
            Contract.Requires(_doctypeData.HasPublicIdentifier);
            _doctypeData.PublicIdentifier += c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AddCharacterToSystemIdentifier(char c)
        {
            Contract.Requires(Type == TokenType.DOCTYPE);
            Contract.Requires(_doctypeData.HasSystemIdentifier);
            _doctypeData.SystemIdentifier += c;
        }

        #endregion

        #region Tag Methods

        /// <summary>
        /// 
        /// </summary>
        public void BeginStartTag()
        {
            Contract.Requires(IsUninitialized);
            Type = TokenType.START_TAG;
            _tagData = new TagData();
        }

        /// <summary>
        /// 
        /// </summary>
        public void BeginEndTag()
        {
            Contract.Requires(IsUninitialized);
            Type = TokenType.END_TAG;
            _tagData = new TagData();
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartNewAttribute()
        {
            Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG);
            _tagData.Attributes.Add(new Attribute());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToAttributeName(char c)
        {
            Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG);
            _tagData.CurrentAttribute.AppendToName(c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToAttributeValue(char c)
        {
            Contract.Requires(Type == TokenType.START_TAG || Type == TokenType.END_TAG);
            _tagData.CurrentAttribute.AppendToValue(c);
        }

        #endregion

        #region Comment Methods

        /// <summary>
        /// 
        /// </summary>
        public void BeginComment()
        {
            Contract.Requires(IsUninitialized);
            Type = TokenType.COMMENT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToComment(char c)
        {
            Contract.Requires(Type == TokenType.COMMENT);
            _data.Append(c);
        }

        #endregion
        #endregion

        #region Nested Classes

        /// <summary>
        /// 
        /// </summary>
        private class DoctypeData
        {
            public string PublicIdentifier;
            public string SystemIdentifier;

            public bool HasPublicIdentifier;
            public bool HasSystemIdentifier;

            public bool ForceQuirks;

            public DoctypeData()
            {
                HasPublicIdentifier = false;
                HasSystemIdentifier = false;

                ForceQuirks = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private class TagData
        {
            public bool IsSelfClosing;
            public List<Attribute> Attributes;
            
            public TagData()
            {
                IsSelfClosing = false;
                Attributes = new List<Attribute>();
            }

            public Attribute CurrentAttribute
            {
                get { return Attributes[Attributes.Count - 1]; }
            }
        }

        #endregion
    }
}
