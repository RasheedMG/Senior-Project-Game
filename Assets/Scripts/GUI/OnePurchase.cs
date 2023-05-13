using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class OnePurchase : MonoBehaviour, IPointerClickHandler
{
    public vendorLogic logic;
    public GameObject panel;
    private TextMeshProUGUI panelAbility;
    public GameObject price;
    int itemPrice;
    void Start()
    {
        logic = GameObject.Find("Vendor Canvas").GetComponent<vendorLogic>();
        panelAbility = panel.GetComponent<AbilityDisplay>().abilityName;
        itemPrice = int.Parse(price.GetComponent<TextMeshProUGUI>().text);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        bool b = logic.purchase(itemPrice);
        if (b)
        {
            PlayerDataManager.currentProf.abilities.Add(new SaveAbility(panelAbility.text));
            panel.SetActive(false);
            if (!PlayerPrefs.HasKey("Versatile"))
            {
                PlayerPrefs.SetInt("Versatile",-1);
                logic.Versatile();
            }
        }
    }
}
