namespace EFCore;

public record PathConfigurations
{
    public string StudentsFileAddress { get; init; }
    public string GradesFileAddress { get; init; }
}