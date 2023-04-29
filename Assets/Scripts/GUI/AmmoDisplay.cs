using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlamAcademy.Guns;
using TMPro;

public class AmmoDisplay : MonoBehaviour
{
    public GunScriptableObject weapon;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammo;
    void Awake()
    {
        weaponName.text = weapon.Type.ToString();
        int currentAmmo = PlayerDataManager.currentProf.getWeapon(weapon.Type.ToString()).currentAmmo;
        int maxAmmo = weapon.AmmoConfig.MaxAmmo;
        ammo.text = currentAmmo.ToString() + "/" + maxAmmo.ToString();
    }

}
