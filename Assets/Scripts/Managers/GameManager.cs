using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private InvLogic invLogic;
    
    public GameState State;

    public static event Action<GameState> OnBeforeStateChanged;
    public static event Action<GameState> OnAfterStateChanged;

    protected override void Awake()
    {
        base.Awake();
        SceneManager.sceneLoaded += GetInventory;
    }

    private void GetInventory(Scene arg0, LoadSceneMode loadSceneMode)
    {
        invLogic = FindObjectOfType<InvLogic>();
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

    public void levelComplete()
    {
        Debug.Log("Level Completed");
        PlayerDataManager.currentProf.currentLevel++;
        invLogic.save();
        LoadLevel("LevelSelect");
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