using System.Collections.Generic;

namespace NovellGame.Models;
public class Scene
{
    public string Id { get; set; }
    public string Text { get; set; }
    public List<Choice> Choices { get; set; }
}
