namespace EFCore.Entity;

public record Grade
{
    public int StudentNumber { get; init; }
    public string Lesson { get; init; }
    public float Score { get; init; }
}