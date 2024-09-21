using Class.TriviaGame.Domain.Dekanat.Extensions;
using Class.TriviaGame.Domain.Dekanat.Models;
using Class.TriviaGame.Domain.Dekanat.Services;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Validator;

public class InputGetterAndValidator
{
    public static string GetAndValidateStudentName()
    {
        while (true)
        {
            Console.WriteLine("\nHello. What is your name: ");
            var nameStudent = Console.ReadLine();

            if (!string.IsNullOrEmpty(nameStudent))
            {
                return nameStudent;
            }
            
            Console.WriteLine("You haven't entered anything!");
        }
    }

    public static int GetAndValidateStudentId(string name)
    {
        while (true)
        {
            Console.WriteLine($"{name}, tell me the number of your credit card: ");
            var isId = int.TryParse(Console.ReadLine(), out var result);

            if (isId)
            {
                return result;
            }
            Console.WriteLine("You didn't enter a number!");
        }
    }

    public static CheckedUserAnswer GetAndCheckUserAnswer(Question question, int score)
    {
        var studentAnswer = UserInput();
        
        if (question.CorrectAnswers.Equals(studentAnswer, StringComparison.OrdinalIgnoreCase))
        {
            score = score.AddWeight(question);

            studentAnswer += " +";
            
            return new CheckedUserAnswer(studentAnswer, score, true);
        }
        
        return new CheckedUserAnswer(studentAnswer, score, false);
    }

    private static bool CorrectInputSymbol(string answer)
    {
        foreach (var item in GenerateSymbolToAnswer.SymbolToAnswers)
        {
            if (item.Symbol.Equals(answer, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
            
            if (item.Answer.Equals(answer, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    private static string UserInput()
    {
        const bool infiniteLoop = true;
        
        while (infiniteLoop)
        {
            Console.Write("Enter the answer (symbol or word): ");
            var answerStudent = Console.ReadLine();
            
            if (answerStudent!.Length == 1)
            {
                if (!CorrectInputSymbol(answerStudent))
                {
                     Console.WriteLine("An invalid character has been entered!\n");
                     
                     continue;
                }
                
                answerStudent = MatchingResponseSymbol.FindResponse(answerStudent);
            }

            return answerStudent;
        }
    }
}
