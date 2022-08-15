using Microsoft.AspNetCore.Mvc;

namespace SearchAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class SearchController
{
    private static string Path = System.IO.Path.Combine(Directory.GetParent(Directory
        .GetParent(Directory.GetParent(Directory.GetCurrentDirectory()).FullName)
        .FullName).FullName, "Phase05/EnglishData");

    private static readonly InvertedIndex.InvertedIndex SearchEngine = new(Path);

    [HttpGet]
    public HashSet<string>? Search([FromQuery(Name = "Query")] string query)
    {
        return SearchEngine.SearchDocsForQuery(query);
    }
}