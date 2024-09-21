using System.Text.Json;
using System.Text.Json.Serialization;
using Class.TriviaGame.Infrastructure.DB.Models;

namespace Class.TriviaGame.Domain.Dekanat.Services;

public static class ReadSettingJson
{
    private static readonly string Path = @"..\..\..\..\Class.TriviaGame.Infrastructure.DB\Settings\setting.json";
   
    public static async Task<Attempts?> ReadAsync()
    {
        string json = await File.ReadAllTextAsync(Path);

        Attempts? attempts = JsonSerializer.Deserialize<Attempts>(json);
        
        return attempts;
    }
}
