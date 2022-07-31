namespace InvertedIndex.Abstraction;

public interface ISearchEngine
{
    
    public void AddToSearchEngine(Dictionary<string, List<string>> newDocs);

    public HashSet<string> SearchForWord(string word);
}