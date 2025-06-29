public class GameEngine
{
    private SceneManager sceneManager;
    public static string userName;
    public GameEngine()
    {
        Console.WriteLine("Введите имя персонажа:");
        userName = Console.ReadLine();
        sceneManager = new SceneManager("Data/scenes.json");
    }

    public void Start()
    {
        
        while (true)
        {
            var currentScene = sceneManager.GetCurrentScene();
            Console.Clear();
            Console.WriteLine(currentScene.getText());

            for (int i = 0; i < currentScene.Choices.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {currentScene.Choices[i].Text}");
            }

            int choice = int.Parse(Console.ReadLine()); //todo обработать исключение
            sceneManager.GoToNextScene(choice - 1);

            if (sceneManager.IsGameOver())
                break;
        }

        Console.WriteLine("Спасибо за игру!");
    }
}