using Class.TriviaGame.Domain.Dekanat.Validator;
using Class.TriviaGame.Domain.Service.Services;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Models;

public static class Exam
{
    private static readonly List<Question> Questions = PreMadeQuestions.Questions;
    
    private static readonly List<Statement> Statement = PreMadeStatements.Statements;
    
    public static int Scores { get; set; }
    
    public static List<string> Answers { get; set; } = [];

    public static void Start(int id, string name)
    {
        Scores = 0;
        
        Answers.Clear();
        
        foreach (var question in Questions)
        {
            GenerateSymbolToAnswer.Generate(question);
            
            QuestionsOutput.Output(question, GenerateSymbolToAnswer.SymbolToAnswers);
            
            InputValidator.GetAndValidateUserInput(question, Answers);
        }
        
        StatementServices.AddNewStatementRecord(
            id, 
            name, 
            Answers, 
            Scores, 
            0, 
            "\nWe record the results in a statement.");
        
        StatementServices.RecordingDataStatement(
            Statement, 
            id, 
            Answers, 
            Scores);
        
        StatementServices.OutStatement(id);
    }
    
    
}