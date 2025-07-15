using NovellGame.Models;
using System.Text.Json.Serialization;

namespace NovellGame.Models;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type",
    UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FailSerialization)]
[JsonDerivedType(typeof(FlagAction), "flagAction")]
[JsonDerivedType(typeof(ChangeStatAction), "ChangeState")]
public interface IAction 
{
    public void Execute(GameState gameState);
}
