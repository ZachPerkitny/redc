using System.Text;

namespace Redc.Browser.Html.Parser
{
    internal class Attribute
    {
        private StringBuilder _name;
        private StringBuilder _value;

        public Attribute()
        {
            _name = new StringBuilder();
            _value = new StringBuilder();
        }

        public string Name
        {
            get { return _name.ToString(); }
        }

        public string Value
        {
            get { return _value.ToString(); }
        }

        public void AppendToName(char c)
        {
            _name.Append(c);
        }

        public void AppendToValue(char c)
        {
            _value.Append(c);
        }
    }
}
