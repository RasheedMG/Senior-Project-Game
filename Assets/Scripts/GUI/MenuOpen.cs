using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class MenuOpen : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{

    public GameObject mainMenu;
    public GameObject subMenu;
    public GameObject original;
    public TextMeshProUGUI newOrload;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameObject.name.Equals("Continue Outline"))
        {
            bool b = false;
            DateTime[] dates = new DateTime[3];
            if (PlayerDataManager.prof1 != null) { 
                dates[0] = SaveManager.getDate(1);
                b = true;
            }
            if (PlayerDataManager.prof2 != null) { 
                dates[1] = SaveManager.getDate(2);
                b = true;
            }
            if (PlayerDataManager.prof3 != null) { 
                dates[2] = SaveManager.getDate(3);
                b = true;
            }
            Array.Sort(dates);
            if (b)
            {
                if (SaveManager.getDate(1) == dates[2])
                {
                    SaveManager.slotNum = 1;
                    PlayerDataManager.currentProf = PlayerDataManager.prof1;
                }
                if (SaveManager.getDate(2) == dates[2])
                {
                    SaveManager.slotNum = 2;
                    PlayerDataManager.currentProf = PlayerDataManager.prof2;
                }
                if (SaveManager.getDate(3) == dates[2])
                {
                    SaveManager.slotNum = 3;
                    PlayerDataManager.currentProf = PlayerDataManager.prof3;
                }
                SceneManager.LoadScene("LevelSelect");
                return;
            }
            else
                return;
        }
        if (gameObject.name.Equals("New Game Outline"))
        {
            SaveManager.isNewGame = true;
            newOrload.text = "Create New Save";
        }
        if (gameObject.name.Equals("Load Game Outline")) { 
            SaveManager.isNewGame = false;
            newOrload.text = "Choose Save to Load";
        }
        if (gameObject.name.Equals("Quit Outline"))
        {
            Application.Quit();
            return;
        }
            

        //mainMenu.SetActive(false);
        subMenu.SetActive(true);
        this.gameObject.SetActive(false);
        original.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
        original.SetActive(true);
    }
}
