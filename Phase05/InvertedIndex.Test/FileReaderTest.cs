using InvertedIndex.Abstraction;

namespace InvertedIndex.Test;

public class FileReaderTest
{
    private readonly IFileReader _fileReader;

    public FileReaderTest()
    {
        _fileReader = new FileReader();
    }

    [Fact]
    public void FileReaderTest_ShouldReturnContainingTxtFiles_WhenReadingAFolderContainingTxtFiles()
    {
        // Arrange
        var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName +
                   "//ReadFolderTest";
        var expected = new Dictionary<string, string>()
        {
            ["1.txt"] = "a",
            ["2.txt"] = "b"
        };
        // Act
        var actual = _fileReader.ReadFolder(path);
        // Assert
        Assert.Equal(expected, actual);
    }
}