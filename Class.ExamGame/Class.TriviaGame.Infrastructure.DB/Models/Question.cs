namespace Class.TriviaGame.Infrastructure.DB.Models;

public class Question(
    int id, 
    string questionText, 
    List<string> answerOptions, 
    string correctAnswers, 
    int weight)
{
    public int Id { get; init; } = id;
    public string QuestionText { get; init; } = questionText;
    public List<string> AnswerOptions { get; init; } = answerOptions;
    public string CorrectAnswers { get; init; } = correctAnswers;
    public int Weight { get; init; } = weight;
}