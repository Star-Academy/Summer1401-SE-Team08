namespace InvertedIndex.Abstraction;

public interface IFileReader
{
    public Dictionary<string, string> ReadFolder(string folder);
}