using FluentAssertions;
using InvertedIndex.Enums;

namespace InvertedIndex.Test;

public class TokenizerTester
{
    [Fact]
    public void Tokenizer_Should_Tokenize_Query()
    {
        // Arrange
        var expected = new List<string>()
        {
            "T_H_E",
            "+B3ST",
            "-T-E-S-T"
        };
        var tokenizer = new Tokenizer(TokenizerMode.Query);
        // Act
        var actual = tokenizer.Tokenize(" | @T_h_e@ $+B3st$ %-T-e-s-t% & ");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Tokenizer_Should_Tokenize_Text()
    {
        // Arrange
        var expected = new List<string>()
        {
            "T_H_E",
            "B3ST",
            "TEST"
        };
        var tokenizer = new Tokenizer(TokenizerMode.Text);
        // Act
        var actual = tokenizer.Tokenize(" | @T_h_e@ $+B3st$ %-T-e-s-t% & ");
        // Assert
        actual.Should().BeEquivalentTo(expected);
    }
}