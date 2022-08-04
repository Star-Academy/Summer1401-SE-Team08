namespace EFCore;

using System.Text.Json;
using EFCore.Database;
using EFCore.Entity;

public class Prgram
{
    public const int NumberOfTopStudents = 3;

    public static void Main(string[] args)
    {
        StudentDatabase database;
        try
        {
            database = new StudentDatabase();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return;
        }

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

    public static List<string> GetTopStudents(StudentDatabase database, int numberOfTopStudents)
    {
        var topStudents = database.Students.Select(s => new
        {
            Average = database.Grades.Where(g => s.StudentNumber == g.StudentNumber).Select(g => g.Score).Average(),
            Student = s
        }).OrderByDescending(t => t.Average).Take(numberOfTopStudents).Select(t =>
            $"FirstName: {t.Student.FirstName}, LastName: {t.Student.LastName}, Average: {t.Average}").ToList();
        return topStudents;
    }
}