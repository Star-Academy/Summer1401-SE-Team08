using InvertedIndex;

namespace Phase05_Console;

public class Program
{
    public static void Main(string[] args)
    {
        var path = @"C:\Users\Arya\OneDrive\Desktop\are\Summer1401-SE-Team08\Phase05-Console\EnglishData";
        InvertedIndex.InvertedIndex index = new InvertedIndex.InvertedIndex(path);
        var result = index.SearchDocsForQuery("God");
        Console.WriteLine(string.Join(", ", result));
    }
}