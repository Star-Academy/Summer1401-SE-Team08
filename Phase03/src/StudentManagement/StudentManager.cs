namespace StudentManagement;

using System.Linq;
public class StudentManager
{
	public List<Student> Students {get; set;}
	public List<Grade> Grades {get; set;}
	public StudentManager()
	{
		this.Students = new List<Student>();
		this.Grades = new List<Grade>();
	}
	public List<string> GetTopStudents(int numberOfTopStudents)
	{
		return Students.Select(s => new {
				Average = Grades.Where(g => g.StudentNumber == s.StudentNumber).Select(y => y.Score).Average(), St=s})
				.OrderByDescending(x => x.Average)
				.Take(numberOfTopStudents)
				.Select(x => $"FirstName: {x.St.FirstName}, LastName: {x.St.LastName}, Average: {x.Average}").ToList();
	}
}