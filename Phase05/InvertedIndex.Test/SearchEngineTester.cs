using InvertedIndex.Abstraction;

namespace InvertedIndex.Test;

using FluentAssertions;
public class SearchEngineTester
{
    private readonly ISearchEngine _searchEngine;

    private readonly Dictionary<string, List<string>> _docs = new Dictionary<string, List<string>>()
    {
        ["1.txt"] = new List<string>()
        {
            "HELLO",
            "MY",
            "NAME",
            "IS",
            "ARYA"
        },
        ["2.txt"] = new List<string>()
        {
            "ARYA",
            "DOESNT",
            "WANT",
            "TO",
            "SAY",
            "HELLO",
            "TO",
            "KHOSRO"
        },
        ["3.txt"] = new List<string>()
        {
            "KHOSRO",
            "LOVES",
            "LINQ"
        }
    };



    public SearchEngineTester()
    {
        _searchEngine = new SearchEngine();
        _searchEngine.AddToSearchEngine(_docs);
    }

   [Fact]
   public void InvertedIndexTest()
    {
        var expected = new HashSet<string> { "1.txt", "2.txt" };
        var actual = _searchEngine.SearchForWord("ARYA");
        Assert.Equal(actual, expected);

        expected = new HashSet<string>() { "2.txt", "3.txt" };
        actual = _searchEngine.SearchForWord("KHOSRO");
        Assert.Equal(actual, expected);
    }
}