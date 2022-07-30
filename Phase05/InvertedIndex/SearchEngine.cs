namespace InvertedIndex;

public class SearchEngine : ISearchEngine
{

    public Dictionary<string, List<string>> DocIdToContents { get; }
    public Dictionary<string, HashSet<string>> WordToDocId ;


    public SearchEngine()
    {
        DocIdToContents = new Dictionary<string, List<string>>();
        WordToDocId = new Dictionary<string, HashSet<string>>();
    }

    public void AddToSearchEngine(Dictionary<string, List<string>> newDocs)
    {
        DocIdToContents.Merge(newDocs);
        foreach (var doc in newDocs)
        {
            AddToWordToDocID(doc.Key,doc.Value);
        }
    }

    private void AddToWordToDocID(string docId, List<string> words)
    {
        foreach(var word in words)
        {
            if (!WordToDocId.ContainsKey(word))
            {
                WordToDocId.Add(word, new HashSet<string>());
            }

            WordToDocId[word].Add(docId);
        }
    }

    public HashSet<string> Search(string word)
    {
        return WordToDocId.ContainsKey(word) ? WordToDocId[word] : new HashSet<string>();
    }
    
}