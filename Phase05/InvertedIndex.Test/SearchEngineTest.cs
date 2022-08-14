using System.Runtime.InteropServices;
using InvertedIndex.Abstraction;

namespace InvertedIndex.Test;

using FluentAssertions;

public class SearchEngineTest
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


    public SearchEngineTest()
    {
        _searchEngine = new SearchEngine();
        _searchEngine.AddToSearchEngine(_docs);
    }
    
    // Arrange
    [Theory]
    [InlineData(new string[] {"1.txt","2.txt"},"ARYA")]
    [InlineData(new string[] {"2.txt","3.txt"},"KHOSRO")]

    public void SearchEngineTest_ShouldReturnFilesContainingAWord_WhenUserSearchesForThatWord(string[] expected, string searchingWord)
    {
        // Act
        var actual = _searchEngine.SearchForWord(searchingWord);
        // Assert
        actual.Should().Equal(new HashSet<string>(expected));
    }
}