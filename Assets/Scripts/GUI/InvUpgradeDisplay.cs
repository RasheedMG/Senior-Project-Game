using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InvUpgradeDisplay : MonoBehaviour
{
    public Upgrade upgrade;
    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI counter;
    void Start()
    {
        string path = "Upgrades/" + gameObject.name;
        upgrade = Resources.Load<Upgrade>(path);
        title.text = upgrade.title;
        desc.text = upgrade.desc;
        counter.text = PlayerDataManager.currentProf.getUpgrade(upgrade.title).count.ToString();
    }

}
