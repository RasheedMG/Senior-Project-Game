using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributeLoader : MonoBehaviour
{
    [SerializeField] float playerHealthMod = 1f;
    [SerializeField] float playerShieldMod = 1f;
    [SerializeField] float playerShieldRateMod = 1f;
    [SerializeField] float playerShieldDelayMod = 1f;
    [SerializeField] float playerArmourMod = 1f;

    int healthUpgradeCount;
    int shieldUpgradeCount; 
    int shieldRateUpgradeCount;
    int shieldDelayUpgradeCount;
    int armourUpgradeCount;


    [SerializeField] float healthMultiplierPerUpgrade = 0.05f;
    [SerializeField] float shieldMultiplierPerUpgrade = 0.05f;
    [SerializeField] float shieldRateMultiplierPerUpgrade = 0.05f;
    [SerializeField] float shieldDelayMultiplierPerUpgrade = -0.05f;
    [SerializeField] float armourMultiplierPerUpgrade = 0.05f;

    [SerializeField] Player player;


    private void Start()
    {
        healthUpgradeCount = PlayerDataManager.currentProf.GetUpgradeCount("Hull");
        playerHealthMod += CalaculateModifier(healthUpgradeCount, healthMultiplierPerUpgrade);

        shieldUpgradeCount = PlayerDataManager.currentProf.GetUpgradeCount("Shield");
        playerShieldMod += CalaculateModifier(shieldUpgradeCount, shieldMultiplierPerUpgrade);

        shieldRateUpgradeCount = PlayerDataManager.currentProf.GetUpgradeCount("Shield"); // Change this.
        playerShieldRateMod += CalaculateModifier(shieldRateUpgradeCount, shieldRateMultiplierPerUpgrade);

        shieldDelayUpgradeCount = PlayerDataManager.currentProf.GetUpgradeCount("Shield"); // Change this.
        playerShieldDelayMod += CalaculateModifier(shieldDelayUpgradeCount, shieldDelayMultiplierPerUpgrade);

        armourUpgradeCount = PlayerDataManager.currentProf.GetUpgradeCount("Plating");
        playerArmourMod += CalaculateModifier(armourUpgradeCount, armourMultiplierPerUpgrade);


        player.PlayerHealthMax *= playerHealthMod;
        
        player.PlayerShieldMax *= playerShieldMod;
        player.shieldRegenerationRate *= playerShieldRateMod;
        player.shieldRegenerationDelay *= playerShieldDelayMod;
        player.PlayerArmourMax *= playerArmourMod;

        player.PlayerHealthCurrent = player.PlayerHealthMax;
        player.PlayerShieldCurrent = player.PlayerShieldMax;
        player.PlayerArmourCurrent = player.PlayerArmourMax;

    }

    private float CalaculateModifier(int upgradeCount, float multiplierPerUpgrade)
    {
        return upgradeCount * multiplierPerUpgrade;

    }




}
