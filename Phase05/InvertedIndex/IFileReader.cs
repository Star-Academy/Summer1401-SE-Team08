namespace InvertedIndex;

public interface IFileReader
{
    public Dictionary<string, string> ReadFolder(string folder);
}