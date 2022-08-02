using InvertedIndex.Abstraction;
using InvertedIndex.Enums;

namespace InvertedIndex;
public class Index
{

    public IQueryBuilder QueryBuilder { get; set; }
    public IHandler QueryHandler { get; set; }
    public ITokenizer Tokenizer { get; set; }

    public Index(SearchEngine engine)
    {
        QueryBuilder = new QueryBuilder();
        Tokenizer = new Tokenizer(TokenizerMode.Text);
        QueryHandler = new QueryHandler(engine);
    }

    public HashSet<string> HandleQuery(string query)
    {
        var @out = QueryHandler.HandleQuery
            (QueryBuilder.BuildQuery(Tokenizer.Tokenize(query)));
        return @out;
    }
    
}
