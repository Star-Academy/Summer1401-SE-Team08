namespace InvertedIndex;

public enum TokenType
{
    And,
    Or,
    Not
}

public static class TokenMethods
{

    public static TokenType GetTokenType(this string token)
    {
        if (token.StartsWith("+"))
        {
            return TokenType.Or;
        } else if (token.StartsWith("-"))
        {
            return TokenType.Not;
        }

        return TokenType.And;
    }
}