using InvertedIndex.Abstraction;

namespace InvertedIndex;

public class QueryHandler : IHandler
{

    private readonly SearchEngine _engine;

    public QueryHandler(SearchEngine engine)
    {
        _engine = engine;
    }

    public HashSet<string> HandleQuery(Query query)
    {
        var universalSet = new HashSet<string>(_engine.DocIdToContents.Keys);
        var answer = GetIntersectionSet(query.AndWords, universalSet);
        if (query.OrWords.Any())
        {
            answer.IntersectWith(GetUnionSet(query.OrWords));
        }

        answer.RemoveWhere(p => GetUnionSet(query.NotWords).Contains(p));
        return answer;
    }

    private HashSet<string> GetUnionSet(List<string> words)
    {
        var set = new HashSet<string>();
        foreach (var word in words)
        {
            set.UnionWith(_engine.SearchForWord(word));
        }

        return set;
    }

    private HashSet<string> GetIntersectionSet(List<string> words, HashSet<string> universalSet)
    {
        HashSet<string> set = new HashSet<string>(universalSet);
        foreach (string word in words)
        {
            set.IntersectWith(_engine.SearchForWord(word));
        }

        return set;
    }
}