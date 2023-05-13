using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class InteractKeyDisplayer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private PlayerInput inputActions;

    private void Awake()
    {
        UpdateKeyDisplay();
    }

    private void OnEnable()
    {
        UpdateKeyDisplay();
    }

    private void UpdateKeyDisplay()
    {
        var bindingPath = inputActions.actions.FindAction("Interact").bindings[0].effectivePath;
        string key = bindingPath.Substring(bindingPath.LastIndexOf('/') + 1);
        label.text = "Interact [" + key.ToUpper() + "]";
    }
}