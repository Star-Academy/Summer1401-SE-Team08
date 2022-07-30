using System;

namespace InvertedIndex;
public class InvertedIndex
{
    public static HashSet<string> Search(string query)
    {
        SearchEngine engine = new SearchEngine();
        ReadFiles(engine);
        return HandleQuery(engine, query);
    }

    private static void ReadFiles(SearchEngine engine)
    {
        var textTokenizer = new Tokenizer(TokenizerMode.Text);
        try
        {
            var fileReader = new FileReader();
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\EnglishData";
            var docs = fileReader.ReadFolder(path);
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

    private static HashSet<string> HandleQuery(SearchEngine engine, string query)
    {
        var handler = new QueryHandler(engine);
        var queryTokenizer = new Tokenizer(TokenizerMode.Query);
        var @out = handler.HandleQuery(new Query(queryTokenizer.Tokenize(query)));
        return @out;
    }
    
}
