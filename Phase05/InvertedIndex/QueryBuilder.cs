using InvertedIndex.Abstraction;
using InvertedIndex.Enums;

namespace InvertedIndex;

public class QueryBuilder : IQueryBuilder
{
    public Query BuildQuery(List<string> query)
    {
        var result = new Query()
        {
            AndWords = new List<string>(),
            OrWords = new List<string>(),
            NotWords = new List<string>()
        };

        foreach (var token in query)
        {
            switch (token.GetTokenType())
            {
                case TokenType.And:
                    result.AndWords.Add(token);
                    break;
                case TokenType.Or:
                    result.OrWords.Add(token[1..]);
                    break;
                case TokenType.Not:
                    result.NotWords.Add(token[1..]);
                    break;
            }
        }

        return result;
    }
}