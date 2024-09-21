using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Services;

public class StatementServices
{
    public static void UpdateStatementAfterQuestions(
        Statement statement,
        List<string> answers,
        int scores,
        string message)
    {
        statement.AnswersToQuestions = answers;
        statement.Scores = scores;
        statement.Attempts += 1;

        Console.WriteLine(message);
    }

    public static void OutStatement(Statement statement)
    {
        var allAnswers = string.Empty;
        
        Console.WriteLine("\n-----Statement of results-----");

        Console.WriteLine($"Credit card no.{statement.Id}");

        Console.WriteLine($"Name: {statement.Name}");

        foreach (var answer in statement.AnswersToQuestions)
        {
            allAnswers += answer + ", ";
        }

        Console.WriteLine($"Answers: {allAnswers}");

        Console.WriteLine($"Attempts: {statement.Attempts}");

        Console.WriteLine($"Scores: {statement.Scores}");

        Console.WriteLine("-------------------------------");
    }
}