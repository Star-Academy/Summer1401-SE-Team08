namespace InvertedIndex;

public interface ISearchEngine
{
    public Dictionary<string, List<string>> GetDocIdToContents();

    public void AddToInvertedIndex(Dictionary<string, List<string>> newDocs);

    public HashSet<string> Search(string word);
}