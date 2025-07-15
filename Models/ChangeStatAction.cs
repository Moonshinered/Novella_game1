using System.Text.Json.Serialization;

namespace NovellGame.Models

{
    public class ChangeStatAction : IAction
    {
        [JsonPropertyName("statN")]
        public string statName { get; set; }
        [JsonPropertyName("value")]
        public int Value { get; set; }
        public void Execute(GameState gameState)
        {
            gameState.GetPlayer().ModifyState(statName, Value);
        }
    }
}
