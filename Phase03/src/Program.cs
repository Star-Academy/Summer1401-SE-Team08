using StudentManagement;
using System.Text.Json;
class Program {
	public const string StudentsFileAddress = "../Data/students.json";
	public const string GradesFileAddress = "../Data/scores.json";
	public const int NumberOfTopStudents = 3;
	static void Main()
	{	
		List<Student> students = new List<Student>();
		List<Grade> grades = new List<Grade>();
		try
		{
			students = JsonSerializer.Deserialize<List<Student>>(File.ReadAllText(StudentsFileAddress));
			grades = JsonSerializer.Deserialize<List<Grade>>(File.ReadAllText(GradesFileAddress));
		}
		catch (Exception e)
		{
			Console.WriteLine(e.ToString());
			return;
		}
		var manager = new StudentManager {Students = students, Grades = grades};
		Console.WriteLine(string.Join('\n', manager.GetTopStudents(NumberOfTopStudents)));
	}
}
