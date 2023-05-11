using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LlamAcademy.Guns;
using LlamAcademy.Guns.Demo;
using UnityEngine.UI;
public class InvWeaponDisplay : MonoBehaviour
{
    public GunScriptableObject weapon;
    public TextMeshProUGUI weaponName;
    public TextMeshProUGUI ammo;
    public Image icon;
    private int maxAmmo;
    private PlayerGunSelector gunSelector;
    private GunScriptableObject weaponClone;

    void Awake()
    {
        gunSelector = GameObject.Find("Player").GetComponent<PlayerGunSelector>();
    }

    void Start()
    {
        string path = "Guns/" + gameObject.name;
        weapon = Resources.Load<GunScriptableObject>(path);
        weaponName.text = weapon.name;
        icon.sprite = weapon.icon;

        weaponClone = gunSelector.instancedGuns.Find(weapon => weapon.Name==gameObject.name);

        ammo.text = weaponClone.AmmoConfig.CurrentClipAmmo.ToString()+"/"+weaponClone.AmmoConfig.MaxAmmo.ToString();
    }

    void Update()
    {
        ammo.text = weaponClone.AmmoConfig.CurrentClipAmmo.ToString() + "/" + weaponClone.AmmoConfig.MaxAmmo.ToString();
    }

}
