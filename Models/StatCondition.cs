using NovellGame.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovellGame.Models;
public class StatCondition : ICondition
{
    [JsonPropertyName("statN")]
    public string statName {  get; set; }
    [JsonPropertyName("value")]
    public int statValue { get; set; }
    [JsonPropertyName("more")]
    public bool isMoreCheck { get; set; }
    public bool IsSatisfied(GameState gameState)
    {
        if (isMoreCheck)
        {
            return gameState.GetPlayerState(statName) >= statValue;
        }
        else
        {
            return gameState.GetPlayerState(statName) < statValue;
        }
    }
}
