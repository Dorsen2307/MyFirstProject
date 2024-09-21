using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Infrastructure.DB.DataBases;

public class StatementDb : IStatementDb
{
    private readonly List<Statement> _statements = PreMadeStatements.Statements;

    public Statement GetExistingOrAddNewAndReturn(int id, string name)
    {
        var foundStatement = GetByIdOrDefault(id);
        if (foundStatement == null)
        {
            var newStatement = new Statement(id, name, new List<string>(), 0, 0);
            _statements.Add(newStatement);
            return newStatement;
        }

        return foundStatement;
    }
    
    public Statement? GetByIdOrDefault(int id)
    {
        var foundStatement = _statements.FirstOrDefault(x => x.Id == id);

        return foundStatement;
    }

    public void AddNewStatement(Statement statement)
    {
        _statements.Add(statement);
    }

    public void UpsertStatement(Statement statement)
    {
        var existing = _statements.FirstOrDefault(x => x.Id == statement.Id);
        if (existing == null)
        {
            _statements.Add(statement);
            return;
        }

        _statements.Remove(existing);
        _statements.Add(statement);
    }
}