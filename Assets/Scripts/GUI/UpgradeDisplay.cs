using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;
    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;
    public int totalCount;
    public TextMeshProUGUI count;
    public TextMeshProUGUI price;
    void Awake()
    {
        this.title.text = upgrade.title;
        this.desc.text = upgrade.desc;
        totalCount = upgrade.upgradeCount;
        if (PlayerDataManager.currentProf.hasUpgrade(upgrade.title))
        {
            count.text = (totalCount - (PlayerDataManager.currentProf.getUpgrade(upgrade.title).count)).ToString();
            if (int.Parse(count.text) == 0)
                gameObject.SetActive(false);
        }
        else
            count.text = upgrade.upgradeCount.ToString();
        this.price.text = upgrade.price.ToString();
    }
}
