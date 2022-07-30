namespace InvertedIndex.Test;

public class QueryTester
{
    private Query _query;

    public QueryTester()
    {
        _query = new Query(
            new List<string>()
            {
                "+SALAM",
                "-KHOB",
                "HASTID?",
                "+MAMNON",
                "+SHOMA",
                "-CHETORID"
            }
            );
    }


    [Fact]
    public void QueryWordsTest()
    {
        Assert.Equal(_query.andWords, new List<string>()
        {
            "HASTID?"
        });
        
        Assert.Equal(_query.orWords, new List<string>()
        {
            "SALAM",
            "MAMNON",
            "SHOMA"
        });
        
        Assert.Equal(_query.notWords, new List<string>()
        {
            "KHOB",
            "CHETORID"
        });
    }
}