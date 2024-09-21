using Class.TriviaGame.Domain.Dekanat.Models;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Services;

public static class StudentValidationServices
{
    public static StudentAndStatementValidationResult ValidateStudentByIdAndName(Statement statement, int studentId, string studentName)
    {
        var isStatementMatchStudentId = IsStatementIdMatchStudentId(statement, studentId);
        
        var isNotCheating = IsStudentNotCheating(statement, studentId, studentName);

        var isAttemptsLeft = IsAttemptsLeft(statement);

        return new StudentAndStatementValidationResult(isStatementMatchStudentId, isNotCheating, isAttemptsLeft);
    }
    
    private static bool IsStatementIdMatchStudentId(Statement statement, int studentId)
    {
        if (statement.Id != studentId)
        {
            Console.WriteLine($"StatementId: {statement.Id} not match StudentId: {studentId}");

            return false;
        }

        return true;
    }
    
    private static bool IsStudentNotCheating(Statement statement, int studentId, string studentName)
    {
        if (!statement.Name.Equals(studentName, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Credit card no.{studentId} belongs to another student.");
            
            return false;
        }

        return true;
    }

    private static bool IsAttemptsLeft(Statement statement)
    {
        var maxAttempts = ReadSettingJson.ReadAsync().Result;

        if (statement.Attempts >= maxAttempts?.MaxAttempts)
        {
            Console.WriteLine($"Max attempts: {maxAttempts} reached: {statement.Attempts}.");
            
            return false;
        }

        Console.WriteLine($"There are {maxAttempts?.MaxAttempts - statement.Attempts} attempts left.");
        return true;
    }
}