using UnityEngine;
using UnityEngine.InputSystem;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] CameraController cameraController;

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
        //Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
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
}
