using InvertedIndex.Abstraction;

namespace InvertedIndex.Test;

public class FileReaderTest
{
    private readonly IFileReader _fileReader;
    private readonly string _path = Directory.GetCurrentDirectory();
    private readonly DirectoryInfo _directoryInfo;

    public FileReaderTest()
    {
        _fileReader = new FileReader();
        _directoryInfo = Directory.CreateDirectory(Path.Combine(_path, "ReadFolderTest"));
    }

    private static void CreateFileWithContent(string path, string content)
    {
        using var writer = File.CreateText(path);
        writer.Write(content);
    }

    [Fact]
    public void ReadFolderTest_ShouldReturnFiles_WhenReadingAFolder()
    {
        // Arrange
        var fileName1 = Path.Combine(_directoryInfo.FullName, "1.txt");
        const string content1 = "a";
        CreateFileWithContent(fileName1, content1);

        var fileName2 = Path.Combine(_directoryInfo.FullName, "2.txt");
        const string content2 = "b";
        CreateFileWithContent(fileName2, content2);
        var expected = new Dictionary<string, string>()
        {
            ["1.txt"] = "a",
            ["2.txt"] = "b"
        };

        // Act
        var actual = _fileReader.ReadFolder(_directoryInfo.FullName);
        File.Delete(fileName1);
        File.Delete(fileName2);
        _directoryInfo.Delete();
        // Assert
        Assert.Equal(expected, actual);
    }
}
