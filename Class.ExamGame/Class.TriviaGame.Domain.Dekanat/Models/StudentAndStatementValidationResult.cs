namespace Class.TriviaGame.Domain.Dekanat.Models;

public record StudentAndStatementValidationResult(bool IsStatementMatchStudent, bool IsNotCheating, bool IsAttemptsLeft);