using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorOpen : MonoBehaviour
{
    public GameObject vendorCanvas;
    public GameObject achievementPopup;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("The Champion")&&PlayerDataManager.currentProf.currentLevel==4)
        {
            PlayerPrefs.SetInt("The Champion", -1);
            TheChampion();
        }
    }
    public void TheChampion()
    {
        GameObject achievement = Instantiate(achievementPopup, gameObject.transform);
        achievement.name = "The Champion";
    }

    public void openVendor()
    {
        gameObject.SetActive(false);
        vendorCanvas.SetActive(true);
    }
}
