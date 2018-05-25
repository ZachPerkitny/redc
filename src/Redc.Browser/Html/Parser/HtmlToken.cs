using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace Redc.Browser.Html.Parser
{
    internal class HtmlToken
    {
        public enum HtmlTokenType
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
        public HtmlTokenType Type { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsUninitialized
        {
            get { return Type == HtmlTokenType.UNITIALIZED; }
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
                Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG || Type == HtmlTokenType.DOCTYPE);
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
                Contract.Requires(Type == HtmlTokenType.DOCTYPE);
                return _doctypeData.ForceQuirks;
            }
            set
            {
                Contract.Requires(Type == HtmlTokenType.DOCTYPE);
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
                Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG);
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
                Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG);
                return _tagData.IsSelfClosing;
            }
            set
            {
                Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG);
                _tagData.IsSelfClosing = value;
            }
        }

        #endregion

        #region Name Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToName(char c)
        {
            Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG || Type == HtmlTokenType.DOCTYPE);
            _data.Append(c);
        }

        #endregion

        #region DocType Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void BeginDocType(char c)
        {
            Contract.Requires(IsUninitialized);
            Type = HtmlTokenType.DOCTYPE;
            _doctypeData = new DoctypeData();

            _data.Append(c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AddCharacterToPublicIdentifier(char c)
        {
            Contract.Requires(Type == HtmlTokenType.DOCTYPE);
            Contract.Requires(_doctypeData.HasPublicIdentifier);
            _doctypeData.PublicIdentifier += c;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AddCharacterToSystemIdentifier(char c)
        {
            Contract.Requires(Type == HtmlTokenType.DOCTYPE);
            Contract.Requires(_doctypeData.HasSystemIdentifier);
            _doctypeData.SystemIdentifier += c;
        }

        #endregion

        #region Tag Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void BeginStartTag(char c)
        {
            Contract.Requires(IsUninitialized);
            Type = HtmlTokenType.START_TAG;
            _tagData = new TagData();

            _data.Append(c);
        }

        /// <summary>
        /// 
        /// </summary>
        public void BeginEndTag(char c)
        {
            Contract.Requires(IsUninitialized);
            Type = HtmlTokenType.END_TAG;
            _tagData = new TagData();

            _data.Append(c);
        }

        /// <summary>
        /// 
        /// </summary>
        public void StartNewAttribute()
        {
            Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG);
            _tagData.Attributes.Add(new Attribute());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToAttributeName(char c)
        {
            Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG);
            _tagData.CurrentAttribute.AppendToName(c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToAttributeValue(char c)
        {
            Contract.Requires(Type == HtmlTokenType.START_TAG || Type == HtmlTokenType.END_TAG);
            _tagData.CurrentAttribute.AppendToValue(c);
        }

        #endregion

        #region Character Methods

        /// <summary>
        /// 
        /// </summary>
        public void EnsureCharacter()
        {
            Contract.Requires(IsUninitialized || Type == HtmlTokenType.CHARACTER);
            Type = HtmlTokenType.CHARACTER;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToCharacter(char c)
        {
            Contract.Requires(Type == HtmlTokenType.CHARACTER);
            _data.Append(c);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public void AppendToCharacter(string str)
        {
            Contract.Requires(Type == HtmlTokenType.CHARACTER);
            _data.Append(str);
        }

        #endregion

        #region Comment Methods

        /// <summary>
        /// 
        /// </summary>
        public void BeginComment()
        {
            Contract.Requires(IsUninitialized);
            Type = HtmlTokenType.COMMENT;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        public void AppendToComment(char c)
        {
            Contract.Requires(Type == HtmlTokenType.COMMENT);
            _data.Append(c);
        }

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
