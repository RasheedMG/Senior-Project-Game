using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    public void LoadLevel(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void UpdateGameState(GameState newState)
    {
        OnBeforeStateChanged?.Invoke(newState);

        State = newState;
        switch (newState)
        {
            case GameState.Continue:
                break;
            case GameState.NewGame:
                break;
            case GameState.LoadGame:
                break;
            case GameState.Victory:
                break;
            case GameState.Defeat:
                break;
            case GameState.Quit:
                Application.Quit();
                break;
            default:
                break;
        }
        OnAfterStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    Continue,
    NewGame,
    LoadGame,
    Victory,
    Defeat,
    Quit
}