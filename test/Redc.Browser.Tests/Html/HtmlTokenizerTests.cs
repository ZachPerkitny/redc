using Redc.Browser.Html.Parser;
using Xunit;

namespace Redc.Browser.Tests.Html
{
    public class HtmlTokenizerTests
    {
        [Theory]
        [InlineData("<a>", "a")]
        [InlineData("<DIV>", "div")]
        [InlineData("<tAbLe>", "table")]
        public void Should_Parse_Start_Tags(string source, string expectedTagName)
        {
            HtmlTokenizer tokenizer = new HtmlTokenizer(source);
            HtmlToken token = tokenizer.GetToken();

            Assert.True(token.Type == HtmlToken.TokenType.START_TAG);
            Assert.Equal(expectedTagName, token.Name);
            Assert.Equal(expectedTagName, token.Data);
        }
    }
}
