namespace InvertedIndex;

public interface IFileReader
{
    public string ReadFile(string file);
    public Dictionary<string, string> ReadFolder(string folder);
}