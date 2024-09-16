using Class.TriviaGame.Domain.Dekanat.Validator;
using Class.TriviaGame.Domain.Service.Services;

namespace Class.TriviaGame.Domain.Dekanat.Models;
    
public class Dekanat : IDekanat
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    private bool IsNextStudentExists { get; set; } = true;

    public void Start()
    {
        while (IsNextStudentExists)
        {
            
            Name = InputValidator.NameInputValidator();

            Id = InputValidator.IdInputValidator(Name);

            var studentFinderStatus = StudentServices.StudentFinder(Id, Name);
            
            if (studentFinderStatus == string.Empty)
            {
                StatementServices.AddNewStatementRecord(
                    Id, 
                    Name, 
                    Exam.Answers, 
                    Exam.Scores, 
                    0,
                    "\nAdding a student record.");
            }

            if (studentFinderStatus == "attempts" || studentFinderStatus == string.Empty)
            {
                Exam.Start(Id, Name);
            }

            IsNextStudentExists = StudentInvitation();
        }
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