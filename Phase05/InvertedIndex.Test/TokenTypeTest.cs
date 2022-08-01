using InvertedIndex.Enums;

namespace InvertedIndex.Test;

public class TokenTypeTester
{
    [Theory]
    [InlineData("+test",TokenType.Or)]
    [InlineData("-test",TokenType.Not)]
    [InlineData("test", TokenType.And)]
    public void String_Matches_Token(string query, TokenType expected)
    {
        var actual = query.GetTokenType();
        Assert.Equal(expected, actual);
    }
}