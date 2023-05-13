using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LlamAcademy.Guns.Demo;
using LlamAcademy.Guns;
using TMPro;
public class InvLogic : MonoBehaviour
{
    CanvasGroup invMenu;
    [SerializeField] CameraController cameraController;
    public GameObject itemPanel;
    public GameObject newItem;
    public GameObject inv;
    public GameObject achievementPopup;
    private GameObject[] items;
    private PlayerGunSelector gunSelector;
    public ItemManager itemManager;
    void Awake()
    {
        invMenu = GetComponentInChildren<CanvasGroup>();
        gunSelector = GameObject.Find("Player").GetComponent<PlayerGunSelector>();
    }

    void Start()
    {
        inv.SetActive(false);
        if (!PlayerPrefs.HasKey("1st Steps"))
        {
        PlayerPrefs.SetInt("1st Steps", -1);
        Invoke("firstGame", 3);
        }
    }

    void firstGame()
    {
        GameObject achievement = Instantiate(achievementPopup,gameObject.transform);
        achievement.name = "1st Steps";
    }

    public void firstDeath()
    {
        GameObject achievement = Instantiate(achievementPopup, gameObject.transform);
        achievement.name = "Skill Issue";
    }

    public void OnInventoryOpen()
    {
        cameraController.enabled = cameraController.enabled ? false : true;
        inv.SetActive(!inv.activeSelf);
        //invMenu.alpha = invMenu.alpha > 0 ? 0 : 1;
        //invMenu.blocksRaycasts = invMenu.blocksRaycasts ? false : true;
        Time.timeScale = Time.timeScale > 0 ? 0 : 1;
    }

    public void ItemPickup(string itemName)
    {
        itemManager.incrementItem(itemName);
    }
    [ContextMenu("Save Game")]
    public void save()
    {
        List<SaveItem> saveItems = itemManager.getItems();
        List<GunScriptableObject> gunList = gunSelector.instancedGuns;
        PlayerDataManager.currentProf.items = saveItems;

        foreach (GunScriptableObject gun in gunList)
        {
            PlayerDataManager.currentProf.setAmmo(gun.Name, gun.AmmoConfig.CurrentClipAmmo);
        }
        SaveManager.SaveData(PlayerDataManager.currentProf);
    }

}
