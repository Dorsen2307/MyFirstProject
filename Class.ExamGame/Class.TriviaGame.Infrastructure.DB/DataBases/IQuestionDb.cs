using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Infrastructure.DB.DataBases;

public interface IQuestionDb
{
    List<Question> GetQuestions();
}