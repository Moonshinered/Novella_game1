using NovellGame.Models;
using System.Collections.Generic;
using System.Text.Json;

public class JsonSceneRepository
{
    private readonly string _filePath;

    public JsonSceneRepository(string filePath)
    {
        _filePath = filePath;
    }

    public Dictionary<string, Scene> LoadScenes()
    {
        string json = File.ReadAllText(_filePath);
        var sceneList = JsonSerializer.Deserialize<List<Scene>>(json);
        return sceneList.ToDictionary(s => s.Id, s => s);
    }
}