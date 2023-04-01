using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeybindsController : MonoBehaviour
{
    [SerializeField] CanvasGroup keybindMenu;
    [SerializeField] CameraController cameraController;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenuVisibility();
        }
    }

    public void ToggleMenuVisibility()
    {
        cameraController.enabled = cameraController.enabled ? false : true;
        Cursor.lockState = Cursor.lockState == CursorLockMode.Locked ? CursorLockMode.None : CursorLockMode.Locked;
        keybindMenu.alpha = keybindMenu.alpha > 0 ? 0 : 1;
        keybindMenu.blocksRaycasts = keybindMenu.blocksRaycasts ? false : true;
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }
}
