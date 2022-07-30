namespace InvertedIndex;

public class FileReader : IFileReader
{
    public string ReadFile(string filePath)
    {
        return System.IO.File.ReadAllText(filePath);
    }

    public Dictionary<string,string> ReadFolder(string directoryPath)
    {
        var docIdToContents = new Dictionary<string, string>();
        foreach (var filePath in System.IO.Directory.GetFiles(directoryPath))
        {
            var fileName = System.IO.Path.GetFileName(filePath);
            var contents = System.IO.File.ReadAllText(filePath);
            docIdToContents.Add(fileName, contents);
        }
        return docIdToContents;
    }
}