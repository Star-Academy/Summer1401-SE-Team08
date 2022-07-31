namespace InvertedIndex.Test;

public class QueryTester
{
    private readonly Query _query;

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
    public void Query_Type_Matches()
    {
        Assert.Equal(_query.AndWords, new List<string>()
        {
            "HASTID?"
        });
        
        Assert.Equal(_query.OrWords, new List<string>()
        {
            "SALAM",
            "MAMNON",
            "SHOMA"
        });
        
        Assert.Equal(_query.NotWords, new List<string>()
        {
            "KHOB",
            "CHETORID"
        });
    }
}