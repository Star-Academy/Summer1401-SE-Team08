using InvertedIndex.Abstraction;

namespace InvertedIndex;


public class FileReader : IFileReader
{

    public Dictionary<string,string> ReadFolder(string directoryPath)
    {
        var docIdToContents = new Dictionary<string, string>();
        foreach (var filePath in Directory.GetFiles(directoryPath))
        {
            var fileName = Path.GetFileName(filePath);
            var contents = File.ReadAllText(filePath);
            docIdToContents.Add(fileName, contents);
        }
        return docIdToContents;
    }
}