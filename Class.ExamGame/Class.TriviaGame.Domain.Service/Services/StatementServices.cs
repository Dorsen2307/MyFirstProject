using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Service.Services;

public class StatementServices
{
    private static readonly List<Statement> Statements = PreMadeStatements.Statements;
    
    public static void AddNewStatementRecord(
        int id, 
        string name, 
        List<string> answers, 
        int scores, 
        int attempts,
        string message)
    {
        Console.WriteLine(message);
        
        Statements.Add(new Statement(id, name, answers, scores, attempts));
    }
    
    public static void RecordingDataStatement(
        List<Statement> statements, 
        int id, 
        List<string> answers, 
        int scores)
    {
        foreach (var statement in statements)
        {
            if (statement.Id == id)
            {
                statement.AnswersToQuestions = answers;
                statement.Scores = scores;
                statement.Attempts += 1;

                break;
            }
        }
    }

    public static void OutStatement(int id)
    {
        Console.WriteLine("\n-----Statement of results-----");
        
        foreach (var statement in Statements)
        {
            var statementAnswersQuestions = string.Empty;
            
            if (statement.Id == id)
            {
                Console.WriteLine($"Credit card no.{statement.Id}");
                
                Console.WriteLine($"Name: {statement.Name}");
                
                foreach (var statementQuestion in statement.AnswersToQuestions)
                {
                    statementAnswersQuestions += statementQuestion + ", ";
                }

                Console.WriteLine($"Answers: {statementAnswersQuestions}");
                
                Console.WriteLine($"Attempts: {statement.Attempts}");
                
                Console.WriteLine($"Scores: {statement.Scores}");
                
                Console.WriteLine("-------------------------------");
                
                return;
            }
        }
    }
}