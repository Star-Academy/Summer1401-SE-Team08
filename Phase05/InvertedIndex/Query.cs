using InvertedIndex.Enums;

namespace InvertedIndex;

public class Query
{
    public List<string> AndWords { get; }
    public List<string> OrWords { get; }
    public List<string> NotWords { get; }


    public Query(List<string> query)
    {
        AndWords = new List<string>();
        OrWords = new List<string>();
        NotWords = new List<string>();
        
        foreach(var token in query)
        {
            switch (token.GetTokenType())
            {
                case TokenType.And:
                    AndWords.Add(token);
                    break;
                case TokenType.Or:
                    OrWords.Add(token.Substring(1));
                    break;
                case TokenType.Not:
                    NotWords.Add(token.Substring(1));
                    break;
            }
        }
        
    }
}