using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] CameraController cameraController;

    [SerializeField] private AbilitySelection abilitySelection;
    
    CanvasGroup pauseMenu;

    private static PauseMenuManager instance;

    public static PauseMenuManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<PauseMenuManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        pauseMenu = GetComponent<CanvasGroup>();
    }

    public void ToggleMenuVisibility()
    {
        cameraController.enabled = cameraController.enabled ? false : true;
        pauseMenu.alpha = pauseMenu.alpha > 0 ? 0 : 1;
        pauseMenu.blocksRaycasts = pauseMenu.blocksRaycasts ? false : true;
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }

    public void BackToMainMenu()
    {
        cameraController.enabled = false;
        Time.timeScale = 1;
    }

    public void OnPauseMenu()
    {
        ToggleMenuVisibility();
    }
    
    public void OnPickAbilitiesButtonClick()
    {
        abilitySelection.ShowAbilitySelectionUI();
    }
}
