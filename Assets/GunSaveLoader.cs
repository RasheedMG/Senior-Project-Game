using LlamAcademy.Guns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlamAcademy.Guns.Demo;


public class GunSaveLoader : MonoBehaviour
{
    private List<string> listOfSavedGuns = new List<string>();



    [SerializeField] public PlayerGunSelector gunSelector;
    [SerializeField]
    private List<GunScriptableObject> Guns;
    [SerializeField]
    private Transform GunParent;
    public Camera Camera;


    private void Awake()
    {
        LoadFromSaveData();

        InitilizeGuns();

        gunSelector.EquipWeapon(gunSelector.instancedGuns[0]);

    }


    private void InitilizeGuns()
    {
        foreach (GunScriptableObject gun in Guns)
        {
            if (listOfSavedGuns.Contains(gun.Name))
            {
                var instantiatedGun = gun.Clone() as GunScriptableObject;
                instantiatedGun.AmmoConfig.CurrentClipAmmo = PlayerDataManager.currentProf.getWeapon(instantiatedGun.Name).currentAmmo;
                gunSelector.instancedGuns.Add(instantiatedGun);
                instantiatedGun.Spawn(GunParent, this, Camera);
                instantiatedGun.RecursiveMeshControl(false);
            }
        }


    }




    public void LoadFromSaveData() 
    {
        List<SaveWeapon> listofsavedweapons = PlayerDataManager.currentProf.getWeapons();

        foreach (SaveWeapon weapon in listofsavedweapons) 
        {
            listOfSavedGuns.Add(weapon.name);

        
        }


    }


}
