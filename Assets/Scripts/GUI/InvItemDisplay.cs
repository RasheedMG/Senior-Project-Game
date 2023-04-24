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

    void Start()
    {
        string path = "Items/" + gameObject.name;
        item = Resources.Load<Item>(path);
        Icon.sprite = item.icon;
        if (!gameObject.name.Equals("Currency"))
                counter.text = PlayerDataManager.currentProf.getItem(item.itemName).count.ToString();
        else
            counter.text = PlayerDataManager.currentProf.currency.ToString();
    }


}
