using NovellGame.Models;

public sealed class GameEngine
{
    private readonly SceneManager _manager;
    private readonly GameState _state;

    public GameEngine(SceneManager manager, GameState state)
    {
        _manager = manager;
        _state = state;
    }

    public Scene CurrentScene => _manager.GetCurrentScene();
    public IReadOnlyList<Choice> GetChoices() => _manager.GetAvailableChoices();
    public bool IsGameOver() => _manager.IsGameOver();

    public void Choose(int index)
    {
        var choice = GetChoices()[index];

        if (choice.Actions != null)
            foreach (var a in choice.Actions)
                a.Execute(_state);

        _manager.GoToNextScene(index);
    }
}
