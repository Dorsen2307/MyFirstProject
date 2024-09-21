using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Extensions;

public static class CounterExtensions
{
    public static int AddWeight(this int score, Question question)
    {
        score += question.Weight;

        return score;
    }
}