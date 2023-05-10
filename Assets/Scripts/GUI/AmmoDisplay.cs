 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlamAcademy.Guns;
using TMPro;
using UnityEngine.UI;
public class AmmoDisplay : MonoBehaviour
{
    public GunScriptableObject weapon;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammo;
    public Image icon;
    void Awake()
    {
        weaponName.text = weapon.name.ToString();
        icon.sprite = weapon.icon;
        int currentAmmo = PlayerDataManager.currentProf.getWeapon(weapon.name.ToString()).currentAmmo;
        int maxAmmo = weapon.AmmoConfig.MaxAmmo;
        ammo.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
    }

}
