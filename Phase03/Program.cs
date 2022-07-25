using System;
using System.Linq;
using System.IO;
using ControllerSpace;
using FileReaderSpace;
using StudentSpace;
using ScoreSpace;
class Program {
  public static string StudentJsonFileAddress = "./Data/students.json";
  public static string ScoreJsonFileAddress = "./Data/scores.json";

  static void Main(){
    var fileReader = new FileReader();
    var students = fileReader.GetStudentsFromFile(StudentJsonFileAddress);
    var scores = fileReader.GetScoresFromFile(ScoreJsonFileAddress);
    var controller = new Controller();
    controller.students = students;
    controller.scores = scores;
    Console.WriteLine(string.Join('\n', controller.GetTopStudents(3)));
  }
}