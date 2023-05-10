using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LlamAcademy.Guns;
using UnityEngine.UI;
public class InvWeaponDisplay : MonoBehaviour
{
    public GunScriptableObject weapon;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammo;
    public Image icon;
    void Start()
    {
        string path = "Guns/" + gameObject.name;
        weapon = Resources.Load<GunScriptableObject>(path);
        weaponName.text = weapon.name;
        icon.sprite = weapon.icon;
        int currentAmmo = PlayerDataManager.currentProf.getWeapon(weapon.name).currentAmmo;
        int maxAmmo = weapon.AmmoConfig.MaxAmmo;
        ammo.text = currentAmmo.ToString()+"/"+maxAmmo.ToString();
    }

}
