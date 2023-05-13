using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] CameraController cameraController;

    [SerializeField] private AbilitySelection abilitySelection;
    
    [SerializeField] private PlayerInput inputActions;
    
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
        cameraController.enabled = !cameraController.enabled;
        pauseMenu.alpha = pauseMenu.alpha > 0 ? 0 : 1;
        pauseMenu.blocksRaycasts = !pauseMenu.blocksRaycasts;
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
        string mapping = cameraController.enabled ? "Player" : "UI";
        inputActions.SwitchCurrentActionMap(mapping);
        Debug.Log(inputActions.currentActionMap);
    }

    public void OnPause(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            ToggleMenuVisibility();
        }
    }

    public void BackToMainMenu()
    {
        cameraController.enabled = false;
        Time.timeScale = 1;
    }

    public void OnPickAbilitiesButtonClick()
    {
        abilitySelection.ShowAbilitySelectionUI();
    }
}
