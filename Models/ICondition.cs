namespace NovellGame.Models;
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type",
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(FlagCondition), "flagCon")]
[JsonDerivedType(typeof(StatCondition), "statCon")]
public interface ICondition 
{
    public bool IsSatisfied(GameState gameState); 
}

