using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemPanelDisplay : MonoBehaviour
{
    public GameObject itemPanel;
    void Awake()
    {
        List<SaveItem> items = PlayerDataManager.currentProf.getItems();
        GameObject currency = Instantiate(itemPanel, this.transform);
        currency.name = "Currency";
        for (int i = 0; i < items.Count; i++)
        {
            GameObject item = Instantiate(itemPanel, this.transform);
            item.name = items[i].itemName;
        }
    }
}
