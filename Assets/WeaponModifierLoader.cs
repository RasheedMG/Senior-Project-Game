using LlamAcademy.Guns;
using LlamAcademy.Guns.Demo;
using LlamAcademy.Guns.Modifiers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponModifierLoader : MonoBehaviour
{

        [SerializeField]
        private PlayerGunSelector GunSelector;
        [SerializeField] float damageMod = 1f;
        [SerializeField] float spreadMod = 1f;
    int gunpowderUpgradeCount; // damage
    int barrelUpgradeCount; // Firerate
    int muzzleUpgradeCount; // Spread


    [SerializeField]float damageMultiplierPerUpgrade = 0.05f;
    [SerializeField]float SpreadMultiplierPerUpgrade = -0.05f;
    [SerializeField]float firerateMultiplierPerUpgrade;


        private void Start()
        {


        gunpowderUpgradeCount = GetUpgradeCount("Gunpowder");
        damageMod += CalaculateModifier(gunpowderUpgradeCount, damageMultiplierPerUpgrade);




        muzzleUpgradeCount = GetUpgradeCount("Muzzel");
        spreadMod += CalaculateModifier(muzzleUpgradeCount, SpreadMultiplierPerUpgrade);


        /*        gunpowderUpgradeCount = GetUpgradeCount("Barrel");
                damageMod = CalaculateModifier(muzzleUpgradeCount, firerateMultiplierPerUpgrade);
        */

        Debug.Log(muzzleUpgradeCount);

        Debug.Log(GunSelector.ActiveGun.ShootConfig.Spread);

        UpdateDamageModifier(damageMod);
        UpdateSpreadModifier(spreadMod);

        Debug.Log(GunSelector.ActiveGun.ShootConfig.Spread);
        Debug.Log(spreadMod);

    }

    private int GetUpgradeCount(string upgradeName)
    {
       var playerUpgrades = PlayerDataManager.currentProf.getUpgrades();
        int upgradeCount = 0;
        foreach (SaveUpgrade upgrade in playerUpgrades)
        {
            if (upgrade.title.Equals(upgradeName))
                upgradeCount = upgrade.count;
        }
        return upgradeCount;
    }

    private float CalaculateModifier(int upgradeCount, float multiplierPerUpgrade)
        {
        return upgradeCount * multiplierPerUpgrade;

        }



    private void UpdateSpreadModifier(float spreadMod)
        {
            Vector3Modifier spreadModifier = new()
            {
                Amount = new Vector3(spreadMod, spreadMod, spreadMod),
                AttributeName = "ShootConfig/Spread"
            };
            foreach (GunScriptableObject gun in GunSelector.instancedGuns)
            {
                spreadModifier.Apply(gun);
            }
        }

        private void UpdateDamageModifier(float damageMod)
        {
            DamageModifier damageModifier = new()
            {
                Amount = damageMod,
                AttributeName = "DamageConfig/DamageCurve"
            };
            foreach (GunScriptableObject gun in GunSelector.instancedGuns)
            {
                damageModifier.Apply(gun);
            }

        }
    
}
