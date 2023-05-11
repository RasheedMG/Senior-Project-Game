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
    private int[] counters;
    private PlayerGunSelector gunSelector;
    void Awake()
    {
        invMenu = GetComponentInChildren<CanvasGroup>();
        gunSelector = GameObject.Find("Player").GetComponent<PlayerGunSelector>();
    }

    void Start()
    {
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
        Transform[] ts = itemPanel.GetComponentsInChildren<Transform>();
        bool exists = true;
        foreach (Transform t in ts)
        {
            if (t.name.Equals(itemName))
            {
                t.GetComponentInChildren<TextMeshProUGUI>().text = (int.Parse(t.GetComponentInChildren<TextMeshProUGUI>().text) + 1).ToString();
                exists = false;
            }
        }
        if (exists)
        {
            GameObject item = Instantiate(newItem, itemPanel.transform);
            item.name = itemName;
            item.GetComponentInChildren<TextMeshProUGUI>().text = "1";
        }
    }
    [ContextMenu("Save Game")]
    public void save()
    {
        items = GameObject.FindGameObjectsWithTag("Item");
        List<SaveItem> saveItems = new List<SaveItem>();
        List<GunScriptableObject> gunList = gunSelector.instancedGuns;

        PlayerDataManager.currentProf.currency = int.Parse(items[0].GetComponentInChildren<TextMeshProUGUI>().text);
        for (int i = 1; i < items.Length; i++)
        {
            saveItems.Add(new SaveItem(items[i].name, int.Parse(items[i].GetComponentInChildren<TextMeshProUGUI>().text)));
        }
        PlayerDataManager.currentProf.items = saveItems;

        foreach (GunScriptableObject gun in gunList)
        {
            PlayerDataManager.currentProf.setAmmo(gun.Name, gun.AmmoConfig.CurrentClipAmmo);
        }
        SaveManager.SaveData(PlayerDataManager.currentProf);
    }

}
