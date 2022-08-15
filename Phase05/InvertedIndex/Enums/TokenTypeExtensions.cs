namespace InvertedIndex.Enums;

public static class TokenTypeExtensions
{
    public static TokenType GetTokenType(this string token)
    {
        if (token.StartsWith("+"))
        {
            return TokenType.Or;
        }
        if (token.StartsWith("-"))
        {
            return TokenType.Not;
        }

        return TokenType.And;
    }
}