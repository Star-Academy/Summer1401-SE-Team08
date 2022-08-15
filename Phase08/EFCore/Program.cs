namespace EFCore;

using System.Text.Json;
using Database;
using Entity;

public class Program
{
    private const int NumberOfTopStudents = 3;
    private const string StudentsFileAddress = "../../../Data/students.json";
    private const string GradesFileAddress = "../../../Data/scores.json";

    public static void Main(string[] args)
    {
        using var database = new StudentDbContext();
        List<Student> students;
        List<Grade> grades;
        try
        {
            students = JsonSerializer.Deserialize<List<Student>>(
                File.ReadAllText(StudentsFileAddress));
            grades = JsonSerializer.Deserialize<List<Grade>>(
                File.ReadAllText(GradesFileAddress));
            database.AddRange(students);
            database.AddRange(grades);
            database.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        var topStudents = GetTopStudents(database, NumberOfTopStudents);
        Console.WriteLine(string.Join('\n', topStudents));
    }

    private static IEnumerable<string> GetTopStudents(StudentDbContext database, int numberOfTopStudents)
    {
        return topStudents = database.Students.Select(s => new
            {
                Average = database.Grades.Where(g => s.StudentNumber == g.StudentNumber)
                    .Select(g => g.Score)
                    .Average(),
                Student = s
            }).OrderByDescending(t => t.Average)
            .Take(numberOfTopStudents)
            .Select(t =>
                $"FirstName: {t.Student.FirstName}, LastName: {t.Student.LastName}, Average: {t.Average}")
            .ToList();
    }
}