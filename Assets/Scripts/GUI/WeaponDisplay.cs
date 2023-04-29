using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlamAcademy.Guns;
using TMPro;

public class WeaponDisplay : MonoBehaviour
{
    public GameObject ammoPanel;
    public GunScriptableObject weapon;
    public TextMeshProUGUI weaponName;
    void Awake()
    {
        weaponName.text = weapon.Type.ToString();
        if (PlayerDataManager.currentProf.hasWeapon(weapon.Type.ToString()))
        {
            gameObject.SetActive(false);
            ammoPanel.SetActive(true);
        }
    }

}
