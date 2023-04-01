using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeListing : MonoBehaviour
{
    public GameObject upgrade;
    public GameObject content;
    private Component[] texts;
    private TextMeshProUGUI title;
    private TextMeshProUGUI details;
    private List<string> upgradeList = new List<string>{"Armor Plate","Gives +1 armor", "Armor Plate", "Gives +1 armor", "Armor Plate",
    "Gives +1 armor","Engine","Increases top speed by 5","Engine","Increases top speed by 5","Engine","Increases top speed by 5","Gunpowder","Increases weapon fire power by 5%","Gunpowder","Increases weapon fire power by 5%"};
    void Start()
    {
        for (int i = 0; i < upgradeList.Count; i = i + 2)
        {
            var item = Instantiate(upgrade);
            texts = item.GetComponentsInChildren<TextMeshProUGUI>();
            title = (TextMeshProUGUI)texts[0];
            title.SetText(upgradeList[i]);
            details = (TextMeshProUGUI)texts[1];
            details.SetText(upgradeList[i + 1]);
            item.transform.parent = content.transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
