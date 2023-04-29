using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using LlamAcademy.Guns;

public class AmmoPurchase : MonoBehaviour, IPointerClickHandler
{
    vendorLogic logic;
    GunScriptableObject weapon;
    public Slider slider;
    public int ammoPrice;
    public GameObject sliderPanel;
    public TextMeshProUGUI price;
    public TextMeshProUGUI ammoCount;
    public TextMeshProUGUI currentAmmo;
    void Start()
    {
        logic = GameObject.Find("Vendor Canvas").GetComponent<vendorLogic>();
        weapon = gameObject.GetComponentInParent<AmmoDisplay>().weapon;
    }

    public void setPrice()
    {
        price.text = (slider.value*ammoPrice).ToString();
        ammoCount.text = slider.value.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int totalPrice;
        bool b = int.TryParse(price.text,out totalPrice);
        if (b)
        {
            if (logic.purchase(totalPrice))
            {
                int limit;
                int index = currentAmmo.text.IndexOf('/');
                int finalAmmo = int.Parse(currentAmmo.text.Substring(0,index));
                finalAmmo = finalAmmo + (totalPrice / ammoPrice);
                limit = int.Parse(currentAmmo.text.Substring(index+1))-finalAmmo;
                string ammoDisplay = finalAmmo.ToString()+currentAmmo.text.Substring(index);
                currentAmmo.text = ammoDisplay;
                PlayerDataManager.currentProf.setAmmo(weapon.Type.ToString(),finalAmmo);
                slider.value = 0;
                slider.maxValue = limit;
                price.text = "";
                if (limit == 0)
                {
                    gameObject.SetActive(false);
                    sliderPanel.SetActive(false);
                }
            }
        }
    }
}
