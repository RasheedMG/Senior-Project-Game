using UnityEngine;
using UnityEngine.InputSystem;

public class KeybindManager : MonoBehaviour
{
    [SerializeField] CameraController cameraController;

    CanvasGroup keybindMenu;

    private static KeybindManager instance;

    public static KeybindManager MyInstance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<KeybindManager>();
            }
            return instance;
        }
    }

    private void Awake()
    {
        keybindMenu = GetComponent<CanvasGroup>();
    }

    public void ToggleMenuVisibility()
    {
        cameraController.enabled = cameraController.enabled ? false : true;
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        keybindMenu.alpha = keybindMenu.alpha > 0 ? 0 : 1;
        keybindMenu.blocksRaycasts = keybindMenu.blocksRaycasts ? false : true;
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }

    public void OnPauseMenu()
    {
        ToggleMenuVisibility();
    }
}
