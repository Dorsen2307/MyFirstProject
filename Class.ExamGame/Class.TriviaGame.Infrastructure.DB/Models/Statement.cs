namespace Class.TriviaGame.Infrastructure.DB.Models;

public class Statement(int id, 
    string name, 
    List<string> answersToQuestions, 
    int scores, 
    int attempts)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public List<string> AnswersToQuestions { get; set; } = answersToQuestions;
    public int Scores { get; set; } = scores;
    public int Attempts { get; set; } = attempts;
}