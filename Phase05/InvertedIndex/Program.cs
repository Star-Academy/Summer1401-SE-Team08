using System;

namespace InvertedIndex;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your sentence to search!");
        var query = Console.ReadLine();
        SearchEngine engine = new SearchEngine();
        ReadFiles(engine);
        
    }

    private static void ReadFiles(SearchEngine engine)
    {
        var textTokenizer = new Tokenizer(TokenizerMode.Text);
        try
        {
            var docs = new Dictionary<string, string>();
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

    private static void HandleQuery(SearchEngine engine, string query)
    {
        var handler = new QueryHandler(engine);
        var queryTokenizer = new Tokenizer(TokenizerMode.Query);
        HashSet<string> @out = handler.HandleQuery(new Query(queryTokenizer.Tokenize(query)));
        PrintResult(@out);

    }



    private static void PrintResult(HashSet<string> result)
    {
        Console.WriteLine("About " + result.Count + " results");
        foreach (var s in result)
        {
            Console.WriteLine("Document name: " + s);
        }
    }
}
