using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class AbilityHolder : MonoBehaviour
{
    Color cooldownBackgroundColor = new Color(0.317f, 0.455f, 1f, 0.604f);
    Color activeBackgroundColor = new Color(1f, 1f, 0f, 0.3f);

    [System.Serializable]
    public class AbilityUI
    {
        public Ability ability;
        public TMPro.TextMeshProUGUI cooldownCounter;
        public Image cooldownBackgroundImage;
        public Image icon;
    }

    [SerializeField] AbilityUI ability1UI;
    [SerializeField] AbilityUI ability2UI;

    float ability1CooldownTime;
    float ability2CooldownTime;

    float ability1ActiveTime;
    float ability2ActiveTime;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }

    AbilityState ability1State = AbilityState.ready;
    AbilityState ability2State = AbilityState.ready;

    private bool ability1Pressed = false;
    private bool ability2Pressed = false;

    private void Start()
    {
        RefreshAbilityIcons();
    }

    private void Update()
    {
        HandleAbilityState(ability1UI, ref ability1ActiveTime, ref ability1CooldownTime, ref ability1State, ability1Pressed);
        HandleAbilityState(ability2UI, ref ability2ActiveTime, ref ability2CooldownTime, ref ability2State, ability2Pressed);
    }
    
    public void RefreshAbilityIcons()
    {
        UpdateAbilityIcon(ability1UI);
        UpdateAbilityIcon(ability2UI);
    }

    private void UpdateAbilityIcon(AbilityUI abilityUI)
    {
        if (abilityUI.ability != null)
        {
            abilityUI.icon.sprite = abilityUI.ability.icon;
            abilityUI.icon.color = new Color(abilityUI.icon.color.r, abilityUI.icon.color.g, abilityUI.icon.color.b, 1f);
        }
        else
        {
            abilityUI.icon.color = new Color(abilityUI.icon.color.r, abilityUI.icon.color.g, abilityUI.icon.color.b, 0f);
        }
    }

    private void HandleAbilityState(AbilityUI abilityUI, ref float activeTime, ref float cooldownTime, ref AbilityState state, bool abilityPressed)
    {
        switch (state)
        {
            case AbilityState.ready:
                abilityUI.cooldownCounter.enabled = false;
                abilityUI.cooldownBackgroundImage.enabled = false;
                if (abilityPressed)
                {
                    abilityUI.ability.Activate(gameObject);
                    state = AbilityState.active;
                    activeTime = abilityUI.ability.activeTime;
                    AudioSystem.Instance.PlayEffect(abilityUI.ability.soundEffect);
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    abilityUI.cooldownBackgroundImage.enabled = true;
                    abilityUI.cooldownBackgroundImage.color = activeBackgroundColor;
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    abilityUI.ability.Deactivate(gameObject);
                    state = AbilityState.cooldown;
                    cooldownTime = abilityUI.ability.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    abilityUI.cooldownBackgroundImage.color = cooldownBackgroundColor;
                    abilityUI.cooldownBackgroundImage.enabled = true;
                    abilityUI.cooldownCounter.enabled = true;
                    abilityUI.cooldownCounter.text = cooldownTime.ToString("0.0");
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }
    }
    
    public Ability GetAbility1()
    {
        return ability1UI.ability;
    }

    public Ability GetAbility2()
    {
        return ability2UI.ability;
    }
    
    public void SwapAbility1(Ability newAbility)
    {
        // Call Deactivate() on the old ability before swapping
        if (ability1UI.ability != null && ability1UI.ability.IsActive)
        {
            ability1UI.ability.Deactivate(gameObject);
        }

        ability1UI.ability = newAbility;
        ability1CooldownTime = ability1UI.ability.cooldownTime;
        ability1State = AbilityState.cooldown;
    }

    public void SwapAbility2(Ability newAbility)
    {
        // Call Deactivate() on the old ability before swapping
        if (ability2UI.ability != null && ability2UI.ability.IsActive)
        {
            ability2UI.ability.Deactivate(gameObject);
        }

        ability2UI.ability = newAbility;
        ability2CooldownTime = ability2UI.ability.cooldownTime;
        ability2State = AbilityState.cooldown;
    }

    public void OnAbility1(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ability1Pressed = true;

            if (ability1State == AbilityState.cooldown)
            {
                AudioSystem.Instance.PlayEffect("Ability On Cooldown");
            }
        }
        else if (context.canceled)
        {
            ability1Pressed = false;
        }
    }

    public void OnAbility2(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            ability2Pressed = true;

            if (ability2State == AbilityState.cooldown)
            {
                AudioSystem.Instance.PlayEffect("Ability On Cooldown");
            }
        }
        else if (context.canceled)
        {
            ability2Pressed = false;
        }
    }
}