namespace IFileReaseSpace;

using StudentSpace;
using ScoreSpace;

interface IFileReader {
  List<Student> GetStudentsFromFile(string fileAddress);

  List<ScoreType> GetScoresFromFile(string fileAddress);
}