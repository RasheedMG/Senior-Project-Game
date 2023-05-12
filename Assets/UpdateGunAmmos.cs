using System.Collections.Generic;
using LlamAcademy.Guns;
using LlamAcademy.Guns.Demo;
using UnityEngine;

public class UpdateGunAmmos : MonoBehaviour
{
    [SerializeField] private PlayerGunSelector _gunSelector;

    public void Start()
    {
        List<GunScriptableObject> equippedGuns = _gunSelector.instancedGuns;

        foreach (GunScriptableObject gun in equippedGuns)
        {
            gun.AmmoConfig.CurrentClipAmmo = PlayerDataManager.currentProf.getWeapon(gun.Name).currentAmmo;
        }
    }
}
