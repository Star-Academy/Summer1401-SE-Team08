using InvertedIndex;

namespace Phase05_Console;

public class Program
{
    public static void Main(string[] args)
    {
        var path = @"C:\Users\Arya\OneDrive\Desktop\are\Summer1401-SE-Team08\Phase05-Console\EnglishData";
        var index = new InvertedIndex.InvertedIndex(path);
        var query = Console.ReadLine();
        var result = index.SearchDocsForQuery(query);
        Console.WriteLine(string.Join(", ", result));
    }
}