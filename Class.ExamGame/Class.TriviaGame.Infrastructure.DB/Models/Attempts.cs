namespace Class.TriviaGame.Infrastructure.DB.Models;

public class Attempts(string name, int maxAttempts)
{
    public string NameMaxAttempts { get; init; } = name;
    public int MaxAttempts { get; init; } = maxAttempts;
}