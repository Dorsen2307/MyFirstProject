using Class.TriviaGame.Domain.Dekanat.Extensions;
using Class.TriviaGame.Domain.Dekanat.Services;
using Class.TriviaGame.Domain.Dekanat.Validator;
using Class.TriviaGame.Infrastructure.DB.DataBases;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Models;
    
public class Dekanat : IDekanat
{

    private readonly IStatementDb _statementDb;
    private readonly IQuestionDb _questionsDb;

    public Dekanat(IStatementDb statementDb, IQuestionDb questionsDb)
    {
        _statementDb = statementDb;
        _questionsDb = questionsDb;
    }

    public void Start()
    {
        var isNextStudentExists = true;
        
        while (isNextStudentExists)
        {
            try
            {
                var statement = GetOrCreateStatement();

                var questions = _questionsDb.GetQuestions();

                Exam.Start(statement, questions);

                isNextStudentExists = StudentInvitation();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }

    private Statement GetOrCreateStatement()
    {
        var studentName = InputGetterAndValidator.GetAndValidateStudentName();

        var studentId = InputGetterAndValidator.GetAndValidateStudentId(studentName);

        var statement = _statementDb.GetExistingOrAddNewAndReturn(studentId, studentName);
            
        var studentAndStatementValidationResult = StudentValidationServices.ValidateStudentByIdAndName(
            statement,
            studentId, 
            studentName);

        if (!studentAndStatementValidationResult.IsStatementMatchStudent)
        {
            throw new StatementException("We don't know each other.");
        }
        if (!studentAndStatementValidationResult.IsNotCheating)
        {
            throw new StatementException("Fuck you cheater!");
        }
        if (!studentAndStatementValidationResult.IsAttemptsLeft)
        {
            throw new StatementException("You don't have any attempts!");
        }

        return statement;
    }

    private bool StudentInvitation()
    {
        Console.Write("\nWe invite the next student? (Y/N)");
               
        var nextStudent = Console.ReadLine();
                
        if (nextStudent == "Y" | nextStudent == "y")
        {
            return true;
        }

        return false;
    }
}

