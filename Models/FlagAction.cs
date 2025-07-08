using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NovellGame.Models;

public sealed class FlagAction : IAction
{
    [JsonPropertyName("flag")]
    public string FlagName { get; set; } = "";
    
    [JsonPropertyName("set")]
    public bool Set { get; set; } = true;

    public void Execute(GameState gameState)
    {
        gameState.SetFlag(FlagName, Set);
    }
}

