using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveWeapon
{
    public string name;
    public int currentAmmo;
    public SaveWeapon(string name, int currentAmmo)
    {
        this.name = name;
        this.currentAmmo = currentAmmo;
    }
}
