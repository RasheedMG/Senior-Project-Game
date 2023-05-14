using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private InvLogic invLogic;
    [SerializeField] private GameObject victoryPanel;
    [SerializeField] private GameObject DefeatPanel;

    [SerializeField] private CameraController cameraController;
    [SerializeField] private PlayerInput inputActions;
    public int enemiesDefeated = 0;


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

    public void levelComplete(int level)
    {
        Debug.Log("Level Completed");
        if (level == PlayerDataManager.currentProf.currentLevel)
        {
            PlayerDataManager.currentProf.currentLevel++;
        }
        PlayerDataManager.currentProf.currency += enemiesDefeated * 50;
        invLogic.save();
        TogglePause();
        victoryPanel.SetActive(true);
    }

    public void LevelLost()
    {
        TogglePause();
        DefeatPanel.SetActive(true);
    }

    public void TogglePause()
    {
        cameraController.enabled = !cameraController.enabled;
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
        string mapping = cameraController.enabled ? "Player" : "UI";
        inputActions.SwitchCurrentActionMap(mapping);
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