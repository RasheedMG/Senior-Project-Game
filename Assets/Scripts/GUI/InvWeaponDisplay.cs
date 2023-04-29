using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LlamAcademy.Guns;
public class InvWeaponDisplay : MonoBehaviour
{
    public GunScriptableObject weapon;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammo;
    void Start()
    {
        string path = "Guns/" + gameObject.name;
        weapon = Resources.Load<GunScriptableObject>(path);
        weaponName.text = weapon.Type.ToString();
        int currentAmmo = PlayerDataManager.currentProf.getWeapon(weapon.Type.ToString()).currentAmmo;
        int maxAmmo = weapon.AmmoConfig.MaxAmmo;
        ammo.text = currentAmmo.ToString()+"/"+maxAmmo.ToString();
    }

}
