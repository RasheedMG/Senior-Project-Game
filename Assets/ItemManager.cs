using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SpeedBoost speedBoost;
    
    [SerializeField] private float repairKitHeal = 30f;
    [SerializeField] private float modKitMultiplier = 2f;

    public void useItem(Item item)
    {
        switch (item.itemName)
        {
            case "Mod Kit":
                Debug.Log("Mod Kit");
                player.PlayerHealthMax *= modKitMultiplier;
                player.PlayerShieldMax *= modKitMultiplier;
                player.Heal(player.PlayerHealthMax);
                player.MaximizeShield();
                break;
            case "Nitrous Gas":
                Debug.Log("Nitrous Gas");
                speedBoost.FillFuel();
                break;
            case "Repair Kit":
                Debug.Log("Repair Kit");
                player.Heal(repairKitHeal);
                break;
            default:
                break;
        }
    }
}
