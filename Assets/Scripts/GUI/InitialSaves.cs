using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialSaves : MonoBehaviour
{
    void Awake()
    {
        SaveManager.slotNum = 1;
        PlayerDataManager.prof1=SaveManager.LoadData();
        SaveManager.slotNum = 2;
        PlayerDataManager.prof2 = SaveManager.LoadData();
        SaveManager.slotNum = 3;
        PlayerDataManager.prof3 = SaveManager.LoadData();
    }
}
