using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityHolder : MonoBehaviour
{
    Color cooldownBackgroundColor = new Color(0.317f, 0.455f, 1f, 0.604f);
    Color activeBackgroundColor = new Color(1f, 1f, 0f, 0.3f);

    [SerializeField] Ability ability1;
    [SerializeField] Ability ability2;

    [SerializeField] TMPro.TextMeshProUGUI ability1CooldownCounter;
    [SerializeField] TMPro.TextMeshProUGUI ability2CooldownCounter;

    [SerializeField] Image ability1CooldownBackgroundImage;
    [SerializeField] Image ability2CooldownBackgroundImage;

    [SerializeField] Image ability1Icon;
    [SerializeField] Image ability2Icon;

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

    private void Update()
    {
        // vvv TEMPORARILY HERE vvv
        RefreshAbilityIcons();
        // ^^^ TEMPORARILY HERE ^^^

        switch (ability1State)
        {
            case AbilityState.ready:
                ability1CooldownCounter.enabled = false;
                ability1CooldownBackgroundImage.enabled = false;
                if (Input.GetButton("Ability 1"))
                {
                    ability1.Activate(gameObject);
                    ability1State = AbilityState.active;
                    ability1ActiveTime = ability1.activeTime;
                }
                break;
            case AbilityState.active:
                if (ability1ActiveTime > 0)
                {
                    ability1CooldownBackgroundImage.enabled = true;
                    ability1CooldownBackgroundImage.color = activeBackgroundColor;
                    ability1ActiveTime -= Time.deltaTime;
                }
                else
                {
                    ability1.Deactivate(gameObject);
                    ability1State = AbilityState.cooldown;
                    ability1CooldownTime = ability1.CooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (ability1CooldownTime > 0)
                {
                    ability1CooldownBackgroundImage.color = cooldownBackgroundColor;
                    ability1CooldownBackgroundImage.enabled = true;
                    ability1CooldownCounter.enabled = true;
                    ability1CooldownCounter.text = ability1CooldownTime.ToString("0.0");
                    ability1CooldownTime -= Time.deltaTime;
                }
                else
                {
                    ability1State = AbilityState.ready;
                }
                break;
        }

        switch (ability2State)
        {
            case AbilityState.ready:
                ability2CooldownCounter.enabled = false;
                ability2CooldownBackgroundImage.enabled = false;
                if (Input.GetButton("Ability 2"))
                {
                    ability2.Activate(gameObject);
                    ability2State = AbilityState.active;
                    ability2ActiveTime = ability2.activeTime;
                }
                break;
            case AbilityState.active:
                if (ability2ActiveTime > 0)
                {
                    ability2CooldownBackgroundImage.enabled = true;
                    ability2CooldownBackgroundImage.color = activeBackgroundColor;
                    ability2ActiveTime -= Time.deltaTime;
                }
                else
                {
                    ability2.Deactivate(gameObject);
                    ability2State = AbilityState.cooldown;
                    ability2CooldownTime = ability2.CooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (ability2CooldownTime > 0)
                {
                    ability2CooldownBackgroundImage.color = cooldownBackgroundColor;
                    ability2CooldownBackgroundImage.enabled = true;
                    ability2CooldownCounter.enabled = true;
                    ability2CooldownCounter.text = ability2CooldownTime.ToString("0.0");
                    ability2CooldownTime -= Time.deltaTime;
                }
                else
                {
                    ability2State = AbilityState.ready;
                }
                break;
        }
    }

    public void RefreshAbilityIcons()
    {
        if (ability1 != null)
        {
            ability1Icon.sprite = ability1.icon;
            ability1Icon.color = new Color(ability1Icon.color.r, ability1Icon.color.g, ability1Icon.color.b, 1f);
        }
        else
        {
            ability1Icon.color = new Color(ability1Icon.color.r, ability1Icon.color.g, ability1Icon.color.b, 0f);
        }

        if (ability2 != null)
        {
            ability2Icon.sprite = ability2.icon;
            ability2Icon.color = new Color(ability2Icon.color.r, ability2Icon.color.g, ability2Icon.color.b, 1f);
        }
        else
        {
            ability2Icon.color = new Color(ability2Icon.color.r, ability2Icon.color.g, ability2Icon.color.b, 0f);
        }
    }

}
