using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlamAcademy.Guns;
using TMPro;
using UnityEngine.UI;

public class WeaponDisplay : MonoBehaviour
{
    public GameObject ammoPanel;
    public GunScriptableObject weapon;
    public TextMeshProUGUI weaponName;
    public Image icon;
    void Awake()
    {
        weaponName.text = weapon.name.ToString();
        icon.sprite = weapon.icon;
        if (PlayerDataManager.currentProf.hasWeapon(weapon.Type.ToString()))
        {
            gameObject.SetActive(false);
            ammoPanel.SetActive(true);
        }
    }

}
