namespace NovellGame.Models;
public class Choice
    {
        public string Text { get; set; }
        public string NextSceneId { get; set; }
        public List<ICondition> Conditions{ get; set; }
        public List<IAction> Actions { get; set; } 
}