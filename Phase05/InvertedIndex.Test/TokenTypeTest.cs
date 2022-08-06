using FluentAssertions;
using InvertedIndex.Enums;

namespace InvertedIndex.Test;

public class TokenTypeTester
{
    // Arrange
    [Theory]
    [InlineData("+test",TokenType.Or)]
    [InlineData("-test",TokenType.Not)]
    [InlineData("test", TokenType.And)]
    public void String_Should_Match_Returned_Token(string query, TokenType expected)
    {
        // Act
        var actual = query.GetTokenType();
        // Assert
        actual.Should().Be(expected);
    }
}