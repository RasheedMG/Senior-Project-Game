using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPanelDisplay : MonoBehaviour
{
    [SerializeField] public ItemManager itemManager;
    public GameObject itemPanel;
    public InvLogic logic;
    void Start()
    {
        GameObject currency = Instantiate(itemPanel, this.transform);
        currency.name = "Currency";
        displayItems(itemManager.getItems());
    }

    public void displayItems(List<SaveItem> items)
    {
        for (int i = 0; i < items.Count; i++)
        {
            displayItem(items, i);
        }
    }

    public void displayItem(List<SaveItem> items, int i)
    {
        GameObject item = Instantiate(itemPanel, this.transform);
        item.name = items[i].itemName;
    }
}
