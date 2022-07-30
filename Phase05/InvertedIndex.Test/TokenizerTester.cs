namespace InvertedIndex.Test;

using FluentAssertions;

public class TokenizerTester
{
    [Fact]
    public void QueryTokenizerTest()
    {
        IEnumerable<string> expected = new List<string>()
        {
            "T_H_E",
            "+B3ST",
            "-T-E-S-T"
        };
        ITokenizer tokenizer = new Tokenizer(TokenizerMode.Query);
        IEnumerable<string> actual = tokenizer.Tokenize(" | @T_h_e@ $+B3st$ %-T-e-s-t% & ");
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TextTokenizerTest() {
        IEnumerable<string> expected = new List<string>()
        {
            "T_H_E",
            "B3ST",
            "TEST"
        };
        ITokenizer tokenizer = new Tokenizer(TokenizerMode.Text);
        IEnumerable<string> actual = tokenizer.Tokenize(" | @T_h_e@ $+B3st$ %-T-e-s-t% & ");
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("random",TokenType.And)]
    [InlineData("+random",TokenType.Or)]
    [InlineData("-random",TokenType.Not)]
    public void TokenTypeTest(string token, TokenType expected)
    {
        TokenType actual = TokenMethods.GetTokenType(token);
        actual.Should().Be(expected);
    }
}