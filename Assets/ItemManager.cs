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
        currencyCount = PlayerDataManager.currentProf.currency;
        foreach (SaveItem item in items)
        {
                 if (item.itemName == "Mod Kit")
                modKitCount = item.count;
            else if (item.itemName == "Nitrous Gas")
                nitrousGasCount = item.count;
            else if (item.itemName == "Repair Kit")
                repairKitCount = item.count;
        }
    }

    public List<SaveItem> getItems()
    {
        List<SaveItem> items = new List<SaveItem>();
            items.Add(new SaveItem("Repair Kit",repairKitCount));
            items.Add(new SaveItem("Nitrous Gas", nitrousGasCount));
            items.Add(new SaveItem("Mod Kit", modKitCount));
        return items;
    }

    public int getCurrency()
    {
        return currencyCount;
    }

    public int getCount(string itemName)
    {
        switch (itemName)
        {
            case "Mod Kit":
                return modKitCount;
            case "Nitrous Gas":
                return nitrousGasCount;
            case "Repair Kit":
                return repairKitCount;
            default:
                return 0;
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

    public void incrementItem(string itemName)
    {
        switch (itemName)
        {
            case "Mod Kit":
                modKitCount++;
                break;
            case "Nitrous Gas":
                nitrousGasCount++;
                break;
            case "Repair Kit":
                repairKitCount++;
                break;
            default:
                break;
        }
    }
}
