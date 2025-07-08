using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
public class GameState
{
    public string CurSceneId { get; set; } = "start";
    private readonly Dictionary<string, bool> _flags = new();

    public void SetFlag(string flagName, bool value)
    {
        _flags[flagName] = value;
    }

    public bool GetFlag(string flagName)
    {
        if (_flags.TryGetValue(flagName, out var value))
        {
            return value;
        }
        return false; // Default value if flag is not set
    }
}