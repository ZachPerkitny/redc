using Redc.Browser.Html.Parser;
using Xunit;

namespace Redc.Browser.Tests.Html
{
    public class HtmlTokenizerTests
    {
        [Fact]
        public void Should_Parse_Start_Tags()
        {
            string source = "<a>";
            HtmlTokenizer tokenizer = new HtmlTokenizer(source);
            HtmlToken token = tokenizer.GetToken();

            Assert.True(token.Type == HtmlToken.TokenType.START_TAG);
            Assert.Equal("a", token.Name);
            Assert.Equal("a", token.Data);
        }
    }
}
