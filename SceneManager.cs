using NVisualNovelGame.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using VisualNovelGame.Models;

public class SceneManager
{
    private Dictionary<string, Scene> scenes;
    private string currentSceneId;
    private Dictionary<string, bool> flags;
    private Dictionary<string, int> stats = new();
    public SceneManager(string pathToFile)
    {
        scenes = LoadScenes(pathToFile);
        currentSceneId = "start";
        flags = new Dictionary<string, bool>();
    }
    public void SetFlag(string key, bool value)
    {
        flags.Add(key, value);
    }
    public Scene GetCurrentScene() => scenes[currentSceneId];

    public void GoToNextScene(int choiceIndex)
    {
        var scene = scenes[currentSceneId];
        currentSceneId = scene.Choices[choiceIndex].NextSceneId;
    }

    public bool IsGameOver() => !scenes.ContainsKey(currentSceneId);

    private Dictionary<string, Scene> LoadScenes(string filePath)
    {
        string json = File.ReadAllText(filePath);
        var sceneList = JsonSerializer.Deserialize<List<Scene>>(json);
        return sceneList.ToDictionary(s => s.Id, s => s);
    }

    // ћетоды выборов и условий
    public bool CheckConditions(List<Condition> conditions)
    {
        for (int i = 0; i < conditions.Count; i++)
        {
            if (!flags.ContainsKey(conditions[i].flagName)
                || !flags[conditions[i].flagName])
            {
                return false;
            }

        }
        return true;
    }
    public List<Choice> GetAvailableChoices(Scene scene)
    {
        var result = new List<Choice>();
        foreach (var choice in scene.Choices)
        {
            if ((choice.Conditions == null || CheckConditions(choice.Conditions))
                && (choice.StatConditions == null || CheckStatConditions(choice.StatConditions)))     
            {
                result.Add(choice); 
            }
        }
        return result;
    }
    //ћетоды —татов
    public void SetStat(string statName, int value)
    {
        stats[statName] = value;
    }
    public void MogifyStat(string statName, int delta)
    {
        if (!stats.ContainsKey(statName))
        {
            stats[statName] = 0;
        }
        stats[statName] += delta;
    }
    public int GetStat(string statName)
    {
        return stats.ContainsKey(statName) ? stats[statName] : 0; //todo возможность чека статов из игры по команде или отображение их все врем€
    }
    public bool CheckStatConditions(List<StatCondition> conditions)
    {
        foreach (var condition in conditions)
        {
            if (!stats.ContainsKey(condition.StatName) || stats[condition.StatName] < condition.MinValue)
                return false;
        }
            return true;
        
    }

}