namespace NovellGame.Models;
using System.Text.Json.Serialization;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type",
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(FlagCondition), "flagCon")]
public interface ICondition 
{
    public bool IsSatisfied(GameState gameState); 
}

