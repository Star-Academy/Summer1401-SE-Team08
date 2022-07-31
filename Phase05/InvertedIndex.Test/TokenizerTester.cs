using FluentAssertions;
using InvertedIndex.Enums;

namespace InvertedIndex.Test;

public class TokenizerTester
{
    [Fact]
    public void QueryTokenizerTest()
    {
        var expected = new List<string>()
        {
            "T_H_E",
            "+B3ST",
            "-T-E-S-T"
        };
        var tokenizer = new Tokenizer(TokenizerMode.Query);
        var actual = tokenizer.Tokenize(" | @T_h_e@ $+B3st$ %-T-e-s-t% & ");
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void TextTokenizerTest() {
        var expected = new List<string>()
        {
            "T_H_E",
            "B3ST",
            "TEST"
        };
        var tokenizer = new Tokenizer(TokenizerMode.Text);
        var actual = tokenizer.Tokenize(" | @T_h_e@ $+B3st$ %-T-e-s-t% & ");
        actual.Should().BeEquivalentTo(expected);
    }
    
    [Theory]
    [InlineData("random",TokenType.And)]
    [InlineData("+random",TokenType.Or)]
    [InlineData("-random",TokenType.Not)]
    public void TokenTypeTest(string token, TokenType expected)
    {
        var actual = token.GetTokenType();
        actual.Should().Be(expected);
    }
}