using System;

namespace InvertedIndex;
public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Enter your sentence to search!");
        var query = Console.ReadLine();
        
    }



    private static void PrintResult(HashSet<string> result, TimeRange time)
    {
        Console.WriteLine("About " + result.Count + " results " + time);
        foreach (var s in result)
        {
            Console.WriteLine("Document name: " + s);
        }
    }
}
