using InvertedIndex;

namespace Phase05_Console;

public class Program
{
    private const string Path = @"C:\Users\Arya\OneDrive\Desktop\are\Summer1401-SE-Team08\Phase05-Console\EnglishData";
    public static void Main(string[] args)
    {
        var index = new InvertedIndex.InvertedIndex(Path);
        var query = Console.ReadLine();
        var result = index.SearchDocsForQuery(query);
        Console.WriteLine(string.Join(", ", result));
    }
}