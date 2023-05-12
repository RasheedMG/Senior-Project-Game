using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentLevel=1;
    public int currency=1000;
    public List<SaveItem> items= new List<SaveItem>();
    public List<SaveUpgrade> upgrades = new List<SaveUpgrade>();
    public List<SaveWeapon> weapons  = new List<SaveWeapon>();
    public List<SaveAbility> abilities = new List<SaveAbility>();
    public PlayerData()
    {

    }

    public void levelComplete()
    {
        this.currentLevel++;
    }

    public int getCurrency()
    {
        return this.currency;
    }

    public void setCurrency(int currency)
    {
        this.currency = currency;
    }

    public SaveItem getItem(string name)
    {
        if (this.items.Count==0)
            return null;
        for(int i = 0; i < this.items.Count; i++)
        {
            if (items[i].itemName.Equals(name))
                return items[i];
        }
        return null;
    }

    public SaveUpgrade getUpgrade(string title)
    {
        if (this.upgrades.Count == 0)
            return null;
        for (int i = 0; i < this.upgrades.Count; i++)
        {
            if (upgrades[i].title.Equals(title))
                return upgrades[i];
        }
        return null;
    }

    public SaveWeapon getWeapon(string name)
    {
        if (this.weapons.Count == 0)
            return null;
        for (int i = 0; i < this.weapons.Count; i++)
        {
            if (weapons[i].name.Equals(name))
                return weapons[i];
        }
        return null;
    }

    public void setItem(string name, int newCount)
    {
        for (int i = 0; i < this.items.Count; i++)
        {
            if (items[i].itemName.Equals(name))
                items[i].count = newCount;
        }
    }

    public void setAmmo(string name, int newCount)
    {
        for (int i = 0; i < this.weapons.Count; i++)
        {
            if (weapons[i].name.Equals(name))
                weapons[i].currentAmmo = newCount;
        }
    }

    public void setUpgrade(string title, int newCount)
    {
        for (int i = 0; i < this.upgrades.Count; i++)
        {
            if (upgrades[i].title.Equals(title))
                upgrades[i].count = newCount;
        }
    }

    public bool hasItem(string name)
    {
        if (this.items.Count == 0)
            return false;
        for (int i = 0; i < this.items.Count; i++)
        {
            if (items[i].itemName.Equals(name))
                return true;
        }
        return false;
    }

    public bool hasUpgrade(string title)
    {
        if (this.upgrades.Count == 0)
            return false;
        for (int i = 0; i < this.upgrades.Count; i++)
        {
            if (upgrades[i].title.Equals(title))
                return true;
        }
        return false;
    }

    public bool hasAbility(string name)
    {
        if (this.abilities.Count == 0)
            return false;
        for (int i = 0; i < this.abilities.Count; i++)
        {
            if (abilities[i].abilityName.Equals(name))
                return true;
        }
        return false;
    }

    public bool hasWeapon(string name)
    {
        if (this.weapons.Count == 0)
            return false;
        for (int i = 0; i < this.weapons.Count; i++)
        {
            if (weapons[i].name.Equals(name))
                return true;
        }
        return false;
    }

    public List<SaveItem> getItems()
    {
        return this.items;
    }

    public List<SaveUpgrade> getUpgrades()
    {
        return this.upgrades;
    }

    public List<SaveAbility> getAbilities()
    {
        return this.abilities;
    }

    public List<SaveWeapon> getWeapons()
    {
        return this.weapons;
    }

    public void setItems(List<SaveItem> items)
    {
        this.items = items;
    }

    public int GetUpgradeCount(string upgradeName)
    {
        int upgradeCount = 0;
        foreach (SaveUpgrade upgrade in upgrades)
        {
            if (upgrade.title.Equals(upgradeName))
                upgradeCount = upgrade.count;
        }
        return upgradeCount;
    }






}
