public static class ConsoleGame
{
    public static void Run()
    {
        var state = new GameState();
        var repo = new JsonSceneRepository("Data/scenes.json");
        var manager = new SceneManager(state, repo);
        var engine = new GameEngine(manager, state);

        Console.Write("Введите имя персонажа: ");
        var userName = Console.ReadLine();

        while (!engine.IsGameOver())
        {
            Console.Clear();
            Console.WriteLine(engine.CurrentScene.Text);

            var choices = engine.GetChoices();
            for (int i = 0; i < choices.Count; i++)
                Console.WriteLine($"{i + 1}. {choices[i].Text}");

            int idx;
            while (true)
            {
                var inp = Console.ReadLine();
                if (int.TryParse(inp, out idx) &&
                    idx >= 1 && idx <= choices.Count)
                {
                    idx--; break;
                }
                Console.WriteLine("Выберите один из предложенных вариантов.");
            }

            engine.Choose(idx);
        }

        Console.WriteLine("Спасибо за игру!");
    }
}
