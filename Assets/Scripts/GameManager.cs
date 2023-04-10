using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

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
        // spawn player
        // spawn enemies
    }

    public void UpdateGameState(GameState newState)
    {
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
            default:
                break;
        }
        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState
{
    Continue,
    NewGame,
    LoadGame,
    Victory,
    Defeat
}