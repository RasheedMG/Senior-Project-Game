using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemDisplay : MonoBehaviour
{
    public Item item;
    public TextMeshProUGUI count;
    public string itemName;
    public Image icon;
    public TextMeshProUGUI price;
    private SaveItem savedItem;
    void Awake()
    {
        this.itemName = item.itemName;
        this.icon.sprite = item.icon;
        this.price.text = item.price.ToString();
        savedItem = PlayerDataManager.currentProf.getItem(itemName);
        if (savedItem != null)
            this.count.text = savedItem.count.ToString();
        else
            this.count.text = "0";
    }

}
