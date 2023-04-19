using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilitySelection : MonoBehaviour
{
    [SerializeField] private GameObject abilitySelectionUI;
    [SerializeField] private GameObject abilityButtonTemplate;
    [SerializeField] private Transform abilityButtonParent;
    [SerializeField] private Transform equippedAbilityButtonParent;
    [SerializeField] private AbilityHolder abilityHolder;
    
    [SerializeField] private List<Ability> availableAbilities;
    
    private int _selectedAbilitySlot = 0;

    /*private List<Ability> availableAbilities = new List<Ability>(); // Update this list with the abilities available to the player*/

    private void Start()
    {
        abilityButtonTemplate.SetActive(false);
        
        // Initialize availableAbilities with some example abilities
        // Remove this block and update the list elsewhere in your game
        /*availableAbilities.Add(Resources.Load<DoubleSpeedAbility>("Abilities/DoubleSpeed"));
        availableAbilities.Add(Resources.Load<TimeWarpAbility>("Abilities/TimeWarp"));
        availableAbilities.Add(Resources.Load<MagicBulletAbility>("Abilities/MagicBullet"));*/
    }

    public void ShowAbilitySelectionUI()
    {
        // Generate the ability buttons
        GenerateAbilityButtons(availableAbilities);
        GenerateEquippedAbilityButtons();

        // Show the Ability Selection UI
        abilitySelectionUI.SetActive(true);
    }

    public void HideAbilitySelectionUI()
    {
        abilitySelectionUI.SetActive(false);
    }
    
    private void GenerateEquippedAbilityButtons()
    {
        // Remove any existing buttons
        foreach (Transform child in equippedAbilityButtonParent)
        {
            Destroy(child.gameObject);
        }

        // Create buttons for the equipped abilities
        Ability[] equippedAbilities = { abilityHolder.GetAbility1(), abilityHolder.GetAbility2() };
        for (int i = 0; i < equippedAbilities.Length; i++)
        {
            Ability ability = equippedAbilities[i];
            int slot = i + 1; // Slot number (1 or 2)

            GameObject newButton = Instantiate(abilityButtonTemplate, equippedAbilityButtonParent);
            newButton.GetComponentInChildren<Image>().sprite = ability.icon;
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = ability.name;

            // Store the selected slot when the player clicks on an equipped ability
            newButton.GetComponent<Button>().onClick.AddListener(() => _selectedAbilitySlot = slot);

            newButton.SetActive(true);
        }
    }

    public void GenerateAbilityButtons(List<Ability> availableAbilities)
    {
        // Remove any existing buttons
        foreach (Transform child in abilityButtonParent)
        {
            Destroy(child.gameObject);
        }

        // Create new buttons for each ability
        foreach (Ability ability in availableAbilities)
        {
            GameObject newButton = Instantiate(abilityButtonTemplate, abilityButtonParent);
            newButton.GetComponentInChildren<Image>().sprite = ability.icon;
            newButton.GetComponentInChildren<TMPro.TextMeshProUGUI>().text = ability.name;
            newButton.GetComponent<Button>().onClick.AddListener(() => SelectAbility(ability));
            newButton.SetActive(true);
        }
    }

    public void SelectAbility(Ability newAbility)
    {
        if (_selectedAbilitySlot == 0)
            return;

        // Swap 1 and 2 if ability is already equipped
        if (abilityHolder.GetAbility1() == newAbility || abilityHolder.GetAbility2() == newAbility)
        {
            // If player swaps an ability with the same ability already in the slot, the game wont swap anything
            if (!(_selectedAbilitySlot == 1 && newAbility == abilityHolder.GetAbility1() ||
                 _selectedAbilitySlot == 2 && newAbility == abilityHolder.GetAbility2()))
            {
                Ability temp = abilityHolder.GetAbility1();
                abilityHolder.SwapAbility1(abilityHolder.GetAbility2());
                abilityHolder.SwapAbility2(temp);
            }
        }
        else
        {
            // Replace the player's current ability with the new ability based on the stored slot value
            if (_selectedAbilitySlot == 1)
            {
                abilityHolder.SwapAbility1(newAbility);
            }
            else if (_selectedAbilitySlot == 2)
            {
                abilityHolder.SwapAbility2(newAbility);
            }
        }

        // Reset the selected ability slot
        _selectedAbilitySlot = 0;

        // Refresh the equipped ability buttons
        GenerateEquippedAbilityButtons();
        
        // Refresh the HUD Abilities
        abilityHolder.RefreshAbilityIcons();

        // Hide the Ability Selection UI
        HideAbilitySelectionUI();
    }
}
