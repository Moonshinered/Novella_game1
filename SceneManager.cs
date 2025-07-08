using NovellGame.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;

public class SceneManager
{
    Dictionary<string, Scene> scenes;
    GameState stage;

    public SceneManager(GameState stage, JsonSceneRepository jsonRepository)
    {
        scenes = jsonRepository.LoadScenes();
        this.stage = stage;
    }

    public Scene GetCurrentScene()
    {
        return scenes[stage.CurSceneId];
    }

    public void GoToNextScene(int choiceIndex)
    {
        try
        {
            var scene = scenes[stage.CurSceneId];
            stage.CurSceneId = scene.Choices[choiceIndex].NextSceneId;
        } catch (KeyNotFoundException)
        {
            Console.WriteLine("Сцена не найдена. Проверьте идентификатор сцены.");
            return;
        }
    }

    public List<Choice> GetAvailableChoices()
    {
        var result = new List<Choice>();
        foreach (var choice in scenes[stage.CurSceneId].Choices) 
        {
            bool isAvailable = true;
            if (choice.Conditions != null)
            {
                foreach (var condition in choice.Conditions)
                {
                    if (!condition.IsSatisfied(stage))
                    {
                        isAvailable = false;
                        break;
                    }
                }
            }

            if (isAvailable)
            {
                result.Add(choice);
            }
        }
        return result;
    }

    public bool IsGameOver() => !scenes.ContainsKey(stage.CurSceneId);
}