using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InvLogic : MonoBehaviour
{
    CanvasGroup invMenu;
    [SerializeField] CameraController cameraController;
    public GameObject itemPanel;
    public GameObject newItem;
    public GameObject inv;

    void Awake()
    {
        invMenu = GetComponentInChildren<CanvasGroup>();
    }

    void Start()
    {

    }

  

    public void OnInventoryOpen()
    {
        cameraController.enabled = cameraController.enabled ? false : true;
        invMenu.alpha = invMenu.alpha > 0 ? 0 : 1;
        invMenu.blocksRaycasts = invMenu.blocksRaycasts ? false : true;
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

}
