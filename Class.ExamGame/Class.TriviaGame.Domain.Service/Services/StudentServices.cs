using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Service.Services;

public static class StudentServices
{
    private static readonly List<Statement> Statements = PreMadeStatements.Statements;
    
    public static string StudentFinder(int id, string name)
    {
        var shortAttempt = 2;

        string validateCheatingStatus = string.Empty;
        
        if (Statements.Count != 0)
        {
            foreach (var statement in Statements)
            {
                validateCheatingStatus = ValidateCheatingStudent(statement, id, name);
                
                if (validateCheatingStatus == string.Empty)
                {
                    var validateStudentDataStatus = ValidateStudentData(statement, id, name, shortAttempt);

                    return validateStudentDataStatus;
                }

                if (validateCheatingStatus == "cheating")
                {
                    return validateCheatingStatus;
                }
            }
        }

        return validateCheatingStatus;
    }
    
    private static string ValidateStudentData(Statement statement, int id, string name, int attempt)
    {
        if (statement.Id == id && statement.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            var attemptsCountStatus = HasRemainingAttemptStudent(statement, attempt);

            return attemptsCountStatus;
        }
        
        return string.Empty;
    }

    private static string ValidateCheatingStudent(Statement statement, int id, string name)
    {
        if (statement.Id == id && !statement.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Credit card no.{id} belongs to another student.");
            
            return "cheating";
        }

        return string.Empty;
    }
    
    private static string HasRemainingAttemptStudent(Statement statement, int attempt)
    {
        if (statement.Attempts < attempt)
        {
            Console.WriteLine($"You have {attempt - statement.Attempts} more attempts.");

            return "attempts";
        }
        
        Console.WriteLine("You don't have any more attempts.");

        return "No attempts";
    }
}