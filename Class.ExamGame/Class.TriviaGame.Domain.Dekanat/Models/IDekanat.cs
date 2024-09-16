namespace Class.TriviaGame.Domain.Dekanat.Models;

public interface IDekanat
{
    int Id { get; set; }
    string? Name { get; set; }
    void Start();
}