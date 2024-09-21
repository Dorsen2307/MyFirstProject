using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Infrastructure.DB.DataBases;

public interface IStatementDb
{
    Statement GetExistingOrAddNewAndReturn(int id, string name);
    Statement? GetByIdOrDefault(int id);
    void AddNewStatement(Statement statement);
    void UpsertStatement(Statement statement);
}