namespace FileReaderSpace;

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text;
using StudentSpace;
using ScoreSpace;
using IFileReaseSpace;

class FileReader{
  public List<Student> GetStudentsFromFile(string fileAddress) {
    var fileInput = File.ReadAllText(fileAddress);
    return JsonSerializer.Deserialize<List<Student>>(fileInput);
  }

  public List<ScoreType> GetScoresFromFile(string fileAddress) {
    var fileInput = File.ReadAllText(fileAddress);
    return JsonSerializer.Deserialize<List<ScoreType>>(fileInput);
  }
}