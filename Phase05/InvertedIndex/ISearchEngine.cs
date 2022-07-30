namespace InvertedIndex;

public interface ISearchEngine
{
    
    public void AddToSearchEngine(Dictionary<string, List<string>> newDocs);

    public HashSet<string> Search(string word);
}