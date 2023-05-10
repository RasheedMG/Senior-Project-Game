using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class vendorLogic : MonoBehaviour
{
    public GameObject itemsPanel;
    public GameObject upgradesPanel;
    public GameObject waPanel;
    public GameObject abilitiesPanel;
    public GameObject itemsOutline;
    public GameObject upgradesOutline;
    public GameObject waOutline;
    public GameObject abilitiesOutline;
    public GameObject broke;
    public TextMeshProUGUI currency;
    public GameObject levelSelect;
    public GameObject achievementPopup;
    public GameObject itemContent;
    private ItemDisplay[] items;
    public GameObject upgradeContent;
    private UpgradeDisplay[] upgrades;

    void Start()
    {
        items = itemContent.GetComponentsInChildren<ItemDisplay>();
        upgrades = upgradeContent.GetComponentsInChildren<UpgradeDisplay>();
        currency.text = PlayerDataManager.currentProf.currency.ToString();
        itemsPanel.SetActive(false);
        upgradesPanel.SetActive(false);
        waPanel.SetActive(false);
        abilitiesPanel.SetActive(false);

    }

    void noMoney()
    {
        broke.SetActive(false);
    }
    public void displayPanel(string name)
    {
        switch (name)
        {
            case "Items":
                itemsPanel.SetActive(true);
                itemsOutline.SetActive(true);
                upgradesPanel.SetActive(false);
                upgradesOutline.SetActive(false);
                waPanel.SetActive(false);
                waOutline.SetActive(false);
                abilitiesPanel.SetActive(false);
                abilitiesOutline.SetActive(false);
                break;
            case "Upgrades":
                itemsPanel.SetActive(false);
                itemsOutline.SetActive(false);
                upgradesPanel.SetActive(true);
                upgradesOutline.SetActive(true);
                waPanel.SetActive(false);
                waOutline.SetActive(false);
                abilitiesPanel.SetActive(false);
                abilitiesOutline.SetActive(false);
                break;
            case "W&A":
                itemsPanel.SetActive(false);
                itemsOutline.SetActive(false);
                upgradesPanel.SetActive(false);
                upgradesOutline.SetActive(false);
                waPanel.SetActive(true);
                waOutline.SetActive(true);
                abilitiesPanel.SetActive(false);
                abilitiesOutline.SetActive(false);
                break;
            case "Abilities":
                itemsPanel.SetActive(false);
                itemsOutline.SetActive(false);
                upgradesPanel.SetActive(false);
                upgradesOutline.SetActive(false);
                waPanel.SetActive(false);
                waOutline.SetActive(false);
                abilitiesPanel.SetActive(true);
                abilitiesOutline.SetActive(true);
                break;
            default:
                break;
        }
    }

    public bool purchase(int price)
    {
        int currentMoney = int.Parse(currency.text);
        if (price > currentMoney)
        {
            broke.SetActive(true);
            Invoke("noMoney",3f);
            return false;
        }
        else
        {
            currentMoney = currentMoney - price;
            currency.text = currentMoney.ToString();
            return true;
        }
    }

    public void GettingStronger()
    {
        GameObject achievement = Instantiate(achievementPopup, gameObject.transform);
        achievement.name = "Getting Stronger";
    }

    public void Save()
    {
        PlayerDataManager.currentProf.currency = int.Parse(currency.text);

        for(int i = 0; i < items.Length; i++)
        {
            if (int.Parse(items[i].count.text) == 0)
                continue;
            if (PlayerDataManager.currentProf.hasItem(items[i].itemName))
                PlayerDataManager.currentProf.setItem(items[i].itemName, int.Parse(items[i].count.text));
            else
                PlayerDataManager.currentProf.items.Add(new SaveItem(items[i].itemName, int.Parse(items[i].count.text)));
        }

        for (int i=0;i<upgrades.Length;i++)
        {
            if (PlayerDataManager.currentProf.hasUpgrade(upgrades[i].title.text))
            {
                PlayerDataManager.currentProf.setUpgrade(upgrades[i].title.text, upgrades[i].totalCount - int.Parse(upgrades[i].count.text));
            }
            else
            {
                if (int.Parse(upgrades[i].count.text) == upgrades[i].totalCount)
                    continue;
                else
                    PlayerDataManager.currentProf.upgrades.Add(new SaveUpgrade(upgrades[i].title.text,upgrades[i].totalCount-int.Parse(upgrades[i].count.text)));
            }
        }

        SaveManager.SaveData(PlayerDataManager.currentProf);
        gameObject.SetActive(false);
        levelSelect.SetActive(true);
    }
}
