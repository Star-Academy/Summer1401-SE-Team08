namespace InvertedIndex;

public class QueryHandler : IHandler
{

    private SearchEngine _engine;

    public void SetIndex(SearchEngine engine)
    {
        this._engine = engine;
    }

    public QueryHandler(SearchEngine engine)
    {
        this._engine = engine;
    }

    public HashSet<string> HandleQuery(Query query)
    {
        var universalSet = new HashSet<string>(_engine.DocIdToContents.Keys);
        var answer = GetIntersectionSet(query.andWords, universalSet);
        if (query.orWords.Any())
        {
            answer.IntersectWith(GetUnionSet(query.orWords));
        }

        answer.RemoveWhere(p => GetUnionSet(query.notWords).Contains(p));
        return answer;
    }

    private HashSet<string> GetUnionSet(List<string> words)
    {
        var set = new HashSet<string>();
        foreach (var word in words)
        {
            set.UnionWith(_engine.Search(word));
        }

        return set;
    }

    private HashSet<string> GetIntersectionSet(List<string> words, HashSet<string> universalSet)
    {
        HashSet<string> set = new HashSet<string>(universalSet);
        foreach (string word in words)
        {
            set.IntersectWith(_engine.Search(word));
        }

        return set;
    }
}