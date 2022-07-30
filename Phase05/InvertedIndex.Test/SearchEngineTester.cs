namespace InvertedIndex.Test;

using FluentAssertions;
public class SearchEngineTester
{
    private ISearchEngine _searchEngine;
    private IFileReader _fileReader;
    
    
    //
    // public SearchEngineTester()
    // {
    //     _searchEngine = new SearchEngine();
    //     _fileReader = new FileReader(); 
    //     string folderPath = "..//EnglishData";
    //     var docIdToContents = _fileReader.ReadFolder(folderPath);
    //     _searchEngine.AddToSearchEngine(docIdToContents);
    //     // add folder to database
    // }

    [Fact]
    public void InvertedIndexTest()
    {

        _searchEngine = new SearchEngine();
        IEnumerable<string> expected = new List<string>()
        {
            
        };
        IEnumerable<string> actual = _searchEngine.Search("TEST");
        actual.Should().BeEquivalentTo(expected);
    }
}