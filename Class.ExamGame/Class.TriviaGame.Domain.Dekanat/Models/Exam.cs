using Class.TriviaGame.Domain.Dekanat.Services;
using Class.TriviaGame.Domain.Dekanat.Validator;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Models;

public static class Exam
{

    public static void Start(Statement statement, List<Question> questions)
    {
        var score = 0;

        var answers = new List<string>();

        // ReadSettingJson.WriteAsync();
        
        foreach (var question in questions)
        {
            GenerateSymbolToAnswer.Generate(question);
            
            QuestionsOutput.Output(question, GenerateSymbolToAnswer.SymbolToAnswers);
            
            var checkedStudentAnswer = InputGetterAndValidator.GetAndCheckUserAnswer(question, score);
            
            answers.Add(checkedStudentAnswer.Answer);

            score = checkedStudentAnswer.score;
        }
        
        StatementServices.UpdateStatementAfterQuestions(
            statement, 
            answers, 
            score,
            "The data has been entered.");
        
        StatementServices.OutStatement(statement);
    }
    
    
}