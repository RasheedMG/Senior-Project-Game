using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    private TextMeshProUGUI currency;

    void Start()
    {
        currency = GameObject.Find("Currency Counter").GetComponent<TextMeshProUGUI>();
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
            return false;
        }
        else
        {
            currentMoney = currentMoney - price;
            currency.text = currentMoney.ToString();
            return true;
        }
    }
}
