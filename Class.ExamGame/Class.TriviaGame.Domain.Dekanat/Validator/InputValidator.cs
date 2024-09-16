using Class.TriviaGame.Domain.Dekanat.Models;
using Class.TriviaGame.Domain.Service.Services;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Validator;

public class InputValidator
{
    public static string NameInputValidator()
    {
        const bool infiniteLoop = true;
        
        while (infiniteLoop)
        {
            Console.WriteLine("\nHello. What is your name: ");
            var nameStudent = Console.ReadLine();

            if (nameStudent != string.Empty)
            {
                return nameStudent!;
            }
            
            Console.WriteLine("You haven't entered anything!");
        }
    }

    public static int IdInputValidator(string name)
    {
        const bool infiniteLoop = true;
        
        while (infiniteLoop)
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

    public static void GetAndValidateUserInput(Question question, List<string> answers)
    {
        var answerStudent = UserInput();
        
        if (question.CorrectAnswers.Equals(answerStudent, StringComparison.OrdinalIgnoreCase))
        {
            Exam.Scores += question.Weight;
            answerStudent += " +";
        }
        answers.Add(answerStudent);
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