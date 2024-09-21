using Class.TriviaGame.Infrastructure.DB.Enums;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Services;

public static class GenerateSymbolToAnswer
{
    public static readonly List<SymbolToAnswer> SymbolToAnswers = [];

    public static void Generate(Question question)
    {
        var i = 0;
        
        SymbolToAnswers.Clear();
        
        foreach (var symbol in Enum.GetNames(typeof(EnumAnswers)))
        {
            SymbolToAnswers.Add(new SymbolToAnswer(symbol, question.AnswerOptions[i++]));
        }
    }

}