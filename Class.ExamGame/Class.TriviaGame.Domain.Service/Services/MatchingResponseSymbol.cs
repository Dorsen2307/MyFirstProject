namespace Class.TriviaGame.Domain.Service.Services;

public class MatchingResponseSymbol
{
    public static string FindResponse(string answerStudent)
    {
        foreach (var item in GenerateSymbolToAnswer.SymbolToAnswers)
        {
            if (item.Symbol.Equals(answerStudent, StringComparison.OrdinalIgnoreCase))
            {
                return item.Answer;
            }
        }

        return answerStudent;
    }
}