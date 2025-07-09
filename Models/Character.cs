namespace NovellGame.Models;
public class Character
{
    public string Name { get; set; }
    public Dictionary<string, int> Stats;
    public Character(
        string name,
        int stranght,
        int agility,
        int endurance,
        int intelegens,
        int charisma)
    {
        Name = name;
        Stats = new();
        Stats.Add("str", stranght);
        Stats.Add("agl", agility);
        Stats.Add("endr", endurance);
        Stats.Add("int", intelegens);
        Stats.Add("chr", charisma);
    }
    public int GetState(string stateName)
    {
        try
        {
            return Stats[stateName];
        }
        catch (KeyNotFoundException)
        {
            throw new ArgumentException("Несуществующий стат " + stateName);
        }
    }


}