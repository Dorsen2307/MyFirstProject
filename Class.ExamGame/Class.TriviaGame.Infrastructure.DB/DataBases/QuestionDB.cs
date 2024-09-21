using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Infrastructure.DB.DataBases;

public class QuestionDb : IQuestionDb
{
    private readonly List<Question> _questions = PreMadeQuestions.Questions;

    public List<Question> GetQuestions()
    {
        return _questions;
    }
}