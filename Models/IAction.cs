using NovellGame.Models;
using System.Text.Json.Serialization;

namespace NovellGame.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type",
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(FlagAction), "flagAction")]
public interface IAction 
{
    public void Execute(GameState gameState);
}
