using UnityEngine;
using UnityEngine.InputSystem;

public class AbilitiesButtonHUDDisplay : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] TMPro.TextMeshProUGUI ability1BindText;
    [SerializeField] TMPro.TextMeshProUGUI ability2BindText;

    public void UpdateAbilityButtons()
    {
        ability1BindText.text = inputActions.FindAction("Ability 1").GetBindingDisplayString(0);
        ability2BindText.text = inputActions.FindAction("Ability 2").GetBindingDisplayString(0);
    }
}
