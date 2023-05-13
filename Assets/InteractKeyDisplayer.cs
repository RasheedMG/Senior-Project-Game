using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class InteractKeyDisplayer : MonoBehaviour
{
    //private PlayerControls inputActions;
    [SerializeField] private GameObject gameManager;
    [SerializeField] private TextMeshProUGUI label;

    /*private void Awake()
    {
        var inputActions = gameManager.GetComponent<>();
        inputActions.Player.Interact.performed += _ => UpdateKeyDisplay();
    }

    private void OnEnable()
    {
        inputActions.Enable();
        UpdateKeyDisplay();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void UpdateKeyDisplay()
    {
        var bindingPath = inputActions.Player.Interact.bindings[0].effectivePath;
        string key = bindingPath.Substring(bindingPath.LastIndexOf('/') + 1);
        label.text = "Interact [" + key.ToUpper() + "]";
    }
    
    private void OnDestroy()
    {
        inputActions.Dispose();
    }*/
}