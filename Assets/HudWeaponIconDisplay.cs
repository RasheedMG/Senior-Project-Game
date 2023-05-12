using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using LlamAcademy.Guns.Demo;
using UnityEngine.UI;

public class HudWeaponIconDisplay : MonoBehaviour
{

    [SerializeField] private PlayerGunSelector GunSelector;
    [SerializeField] public Image image;

    // Start is called before the first frame update

    void Awake()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        image.sprite = GunSelector.ActiveGun.icon;
        
    }
}
