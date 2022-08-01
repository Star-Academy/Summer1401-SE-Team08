using InvertedIndex.Abstraction;
using InvertedIndex.Enums;



namespace InvertedIndex;
public class InvertedIndex
{

    private readonly IQueryBuilder _queryBuilder;
    private readonly string _path;
    
    public InvertedIndex(string path)
    {
        _queryBuilder = new QueryBuilder();
        _path = path;
    }
    public HashSet<string> SearchDocsForQuery(string query)
    {
        var engine = new SearchEngine();
        ReadFiles(engine);
        return HandleQuery(engine, query);
    }

    private void ReadFiles(SearchEngine engine)
    {
        var textTokenizer = new Tokenizer(TokenizerMode.Text);
        try
        {
            var fileReader = new FileReader();
            var docs = fileReader.ReadFolder(_path);
            var tokenizedDocs = new Dictionary<string, List<string>>();
            foreach (var key in docs.Keys)
            {
                tokenizedDocs[key] = textTokenizer.Tokenize(docs[key]);
            }
            engine.AddToSearchEngine(tokenizedDocs);
            
        }
        catch (Exception e)
        {
            Console.WriteLine(e.StackTrace);
        }
    }

    private HashSet<string> HandleQuery(SearchEngine engine, string query)
    {
        var handler = new QueryHandler(engine);
        var queryTokenizer = new Tokenizer(TokenizerMode.Query);
        var @out = handler.HandleQuery(_queryBuilder.BuildQuery(queryTokenizer.Tokenize(query)));
        return @out;
    }
    
}
