using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private SpeedBoost speedBoost;
    
    [SerializeField] private float repairKitHeal = 30f;
    [SerializeField] private float modKitMultiplier = 2f;

    public int currencyCount;
    public int modKitCount;
    public int nitrousGasCount;
    public int repairKitCount;

    private void Awake()
    {
        LoadSavedItems();
    }

    private void LoadSavedItems()
    {
        List<SaveItem> items = PlayerDataManager.currentProf.getItems();
        foreach (SaveItem item in items)
        {
            if (item.itemName == "Currency")
                currencyCount = item.count;
            else if (item.itemName == "Mod Kit")
                modKitCount = item.count;
            else if (item.itemName == "Nitrous Gas")
                nitrousGasCount = item.count;
            else if (item.itemName == "Repair Kit")
                repairKitCount = item.count;
        }
    }


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
