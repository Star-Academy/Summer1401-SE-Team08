namespace EFCore;

using System.Text.Json;
using Database;
using Entity;

public class Program
{
    private const int NumberOfTopStudents = 3;

    public static void Main(string[] args)
    {
        using var database = new StudentDatabase();

        PathConfigurations pathConfigurations;
        List<Student> students;
        List<Grade> grades;
        try
        {
            pathConfigurations =
                JsonSerializer.Deserialize<PathConfigurations>(
                    File.ReadAllText("../../../PathConfigurations.json"));
            students = JsonSerializer.Deserialize<List<Student>>(
                File.ReadAllText(pathConfigurations.StudentsFileAddress));
            grades = JsonSerializer.Deserialize<List<Grade>>(
                File.ReadAllText(pathConfigurations.GradesFileAddress));
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

    private static IEnumerable<string> GetTopStudents(StudentDatabase database, int numberOfTopStudents)
    {
        var topStudents = database.Students.Select(s => new
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
        return topStudents;
    }
}