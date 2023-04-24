using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePanelDisplay : MonoBehaviour
{
    public GameObject upgradePanel;
    public GameObject upgradePrefab;
    void Awake()
    {
        List<SaveUpgrade> upgrades = PlayerDataManager.currentProf.getUpgrades();
        for (int i = 0; i < upgrades.Count; i++)
        {
            GameObject upgrade = Instantiate(upgradePrefab, upgradePanel.transform);
            upgrade.name = upgrades[i].title;
        }
    }

}
