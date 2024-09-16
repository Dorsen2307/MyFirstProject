using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Models;

public static class QuestionsOutput
{
    public static void Output(Question question, List<SymbolToAnswer> symbolToAnswers)
    {
        Console.WriteLine($"\nQuestion №{question.Id}");
        
        Console.WriteLine($"Question: {question.QuestionText}");
            
        Console.WriteLine("Answer options:");
        foreach (var answer in symbolToAnswers)
        {
            Console.WriteLine($"{answer.Symbol}. {answer.Answer}");
        }
    }
}