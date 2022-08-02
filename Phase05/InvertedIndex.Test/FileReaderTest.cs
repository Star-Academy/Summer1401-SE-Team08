// using InvertedIndex.Abstraction;
//
// namespace InvertedIndex.Test;
//
// public class FileReaderTest
// {
//     private readonly IFileReader _fileReader;
//
//     public FileReaderTest()
//     {
//         _fileReader = new FileReader();
//     }
//     [Fact]
//     public void Read_Folder_Result()
//     {
//         var path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +
//                    "\\ReadFolderTest";
//         var actual = _fileReader.ReadFolder(path);
//         var expected = new Dictionary<string, string>()
//         {
//             ["1.txt"] = "a",
//             ["2.txt"] = "b"
//         };
//         Assert.Equal(expected,actual);
//     }
// }