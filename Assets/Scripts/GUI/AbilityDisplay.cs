using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AbilityDisplay : MonoBehaviour
{
    public Ability ability;
    public TextMeshProUGUI abilityName;
    public Image icon;
    public TextMeshProUGUI CD;
    void Awake()
    {
        abilityName.text = ability.name;
        this.icon.sprite = ability.icon;
        CD.text ="Cooldown: "+ability.cooldownTime.ToString();
        if (PlayerDataManager.currentProf.hasAbility(ability.name))
            gameObject.SetActive(false);
    }
}
