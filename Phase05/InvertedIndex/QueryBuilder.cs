using InvertedIndex.Abstraction;
using InvertedIndex.Enums;

namespace InvertedIndex;

public class QueryBuilder : IQueryBuilder
{
    public Query BuildQuery(List<string> query)
    {
        var andWords = new List<string>();
        var orWords = new List<string>();
        var notWords = new List<string>();
        var result = new Query();
        
        foreach(var token in query)
        {
            switch (token.GetTokenType())
            {
                case TokenType.And:
                    andWords.Add(token);
                    break;
                case TokenType.Or:
                    orWords.Add(token[1..]);
                    break;
                case TokenType.Not:
                    notWords.Add(token[1..]);
                    break;
            }
        }

        result.AndWords = andWords;
        result.OrWords = orWords;
        result.NotWords = notWords;
        return result;
    }
}