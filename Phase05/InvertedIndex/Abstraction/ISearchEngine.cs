namespace InvertedIndex.Abstraction;

public interface ISearchEngine
{

    public Dictionary<string, List<string>> DocIdToContents { get; set; }    
    public void AddToSearchEngine(Dictionary<string, List<string>> newDocs);

    public HashSet<string> SearchForWord(string word);
}