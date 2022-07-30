namespace InvertedIndex.Test;

public class FileReaderTest
{
    private readonly FileReader _fileReader;

    public FileReaderTest()
    {
        this._fileReader = new FileReader();
    }
    [Fact]
    public void ReadFolderTest()
    {
        var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
                   "\\ReadFolderTest";
        var actual = _fileReader.ReadFolder(path);
        var expected = new Dictionary<string, string>()
        {
            ["1.txt"] = "a",
            ["2.txt"] = "b"
        };
        Assert.Equal(expected,actual);
    }
}