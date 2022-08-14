using Microsoft.AspNetCore.Mvc;

namespace SearchAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class SearchController
{
    private const string Path = @"C:\Users\Arya\OneDrive\Desktop\EnglishData";
    private static readonly InvertedIndex.InvertedIndex SearchEngine = new(Path);

    [HttpGet]
    public HashSet<string>? Search([FromQuery(Name = "Query")] string query)
    {
        return SearchEngine.SearchDocsForQuery(query);
    }
}