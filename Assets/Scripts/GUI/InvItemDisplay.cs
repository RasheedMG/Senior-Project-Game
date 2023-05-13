using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InvItemDisplay : MonoBehaviour
{
    public Item item;
    public Image Icon;
    public TextMeshProUGUI counter;
    private ItemManager itemManager;

    private void Awake()
    {
        itemManager = GetComponentInParent<ItemPanelDisplay>().itemManager;
    }

    void Start()
    {
        string path = "Items/" + gameObject.name;
        item = Resources.Load<Item>(path);
        Icon.sprite = item.icon;
        gameObject.tag = "Item";
        Button button = GetComponent<Button>();
        button.onClick.AddListener(() => useItem());
        if (!gameObject.name.Equals("Currency"))
                counter.text = PlayerDataManager.currentProf.getItem(item.itemName).count.ToString();
        else
            counter.text = PlayerDataManager.currentProf.currency.ToString();
    }

    public void useItem()
    {
        if (!gameObject.name.Equals("Currency"))
        {
            int itemCount = int.Parse(counter.text);

            if (itemCount > 0)
            {
                itemManager.useItem(item);
                counter.text = (itemCount - 1).ToString();
                if (itemCount - 1 <= 0)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

}
