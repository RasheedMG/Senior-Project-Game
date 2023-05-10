using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using LlamAcademy.Guns;
using TMPro;
public class WeaponPurchase : MonoBehaviour, IPointerClickHandler
{
    public vendorLogic logic;
    public GameObject weaponPanel;
    public GameObject ammoPanel;
    public GameObject price;
    GunScriptableObject weapon;
    int itemPrice;

    void Start()
    {
        logic = GameObject.Find("Vendor Canvas").GetComponent<vendorLogic>();
        weapon = weaponPanel.GetComponent<WeaponDisplay>().weapon;
        itemPrice = int.Parse(price.GetComponent<TextMeshProUGUI>().text);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (logic.purchase(itemPrice)) {
            PlayerDataManager.currentProf.weapons.Add(new SaveWeapon(weapon.name, weapon.AmmoConfig.MaxAmmo));
            weaponPanel.SetActive(false);
            ammoPanel.SetActive(true); 
        }
    }
}
