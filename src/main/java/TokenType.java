public enum TokenType {
    AND,
    OR,
    NOT;

    public static TokenType getTokenType(String token) {
        if (token.startsWith("+")){
          return TokenType.OR;
        }
        else if (token.startsWith("-")){
          return TokenType.NOT;
        }
        return TokenType.AND;
    }
}