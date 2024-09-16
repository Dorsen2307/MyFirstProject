using Class.TriviaGame.Infrastructure.DB.Enums;

namespace Class.TriviaGame.Infrastructure.DB.Models;

public class SymbolToAnswer(string symbol, string answer)
{
    public string Symbol { get; set; } = symbol;
    public string Answer { get; set; } = answer;
}