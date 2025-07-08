using System.Text.Json.Serialization;

namespace NovellGame.Models;
public sealed class FlagCondition : ICondition
{
    [JsonPropertyName("flag")]
    public string FlagName {get; set; } = "";

    public bool IsSatisfied(GameState gameState)
    {
        return gameState.GetFlag(FlagName);
    }
}