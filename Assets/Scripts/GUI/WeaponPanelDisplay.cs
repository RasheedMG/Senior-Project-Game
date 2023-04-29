using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPanelDisplay : MonoBehaviour
{
    public GameObject weaponPanel;
    public GameObject weaponPrefab;
    void Awake()
    {
        List<SaveWeapon> weapons = PlayerDataManager.currentProf.getWeapons();
        for (int i = 0; i < weapons.Count; i++)
        {
            GameObject weapon = Instantiate(weaponPrefab, weaponPanel.transform);
            weapon.name = weapons[i].name;
        }
    }
}
