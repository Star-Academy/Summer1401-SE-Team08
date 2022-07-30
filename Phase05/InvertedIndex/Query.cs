using System.Text.Json;

namespace InvertedIndex;

public class Query
{
    public List<string> andWords { get; }
    public List<string> orWords { get; }
    public List<string> notWords { get; }


    public Query(List<string> query)
    {
        andWords = new List<string>();
        orWords = new List<string>();
        notWords = new List<string>();
        
        foreach(var token in query)
        {
            switch (token.GetTokenType())
            {
                case TokenType.And:
                    andWords.Add(token);
                    break;
                case TokenType.Or:
                    orWords.Add(token.Substring(1));
                    break;
                case TokenType.Not:
                    notWords.Add(token.Substring(1));
                    break;
            }
        }
        
    }
}