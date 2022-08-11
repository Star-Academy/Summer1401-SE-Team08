using FluentAssertions;
using InvertedIndex.Enums;

namespace InvertedIndex.Test;

public class TokenTypeTester
{
    // Arrange
    [Theory]
    [InlineData("+test", TokenType.Or)]
    [InlineData("-test", TokenType.Not)]
    [InlineData("test", TokenType.And)]
    public void TokenTypeTest_ShouldReturnMatchingToken_WhenGivenAString(string query, TokenType expected)
    {
        // Act
        var actual = query.GetTokenType();
        // Assert
        actual.Should().Be(expected);
    }
}