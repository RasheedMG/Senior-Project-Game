using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;
public class SavePanel : MonoBehaviour, IPointerClickHandler
{
    public GameObject empty;
    public GameObject saveData;
    public TextMeshProUGUI level;
    public TextMeshProUGUI playtime;
    public TextMeshProUGUI lastPlayed;
    void Start()
    {
        switch (gameObject.name)
        {
            case "Save 1 Panel":
                {
                    if (PlayerDataManager.prof1 == null)
                    {
                        empty.SetActive(true);
                        saveData.SetActive(false);
                    }
                    else
                    {
                        empty.SetActive(false);
                        saveData.SetActive(true);
                        if (PlayerDataManager.prof1.currentLevel == 4)
                            level.text = "All levels completed!";
                        else
                        {
                            int lv = PlayerDataManager.prof1.currentLevel;
                            level.text = "Level " + lv;
                        }
                        lastPlayed.text = SaveManager.getDate(1).ToString("MM/dd/yyyy hh:mm tt"); ;
                    }
                break;
                }
            case "Save 2 Panel":
                {
                    if (PlayerDataManager.prof2 == null)
                    {
                        saveData.SetActive(false);
                    }
                    else
                    {
                        empty.SetActive(false);
                        if (PlayerDataManager.prof2.currentLevel == 4)
                            level.text = "All levels completed!";
                        else
                        {
                            int lv = PlayerDataManager.prof2.currentLevel;
                            level.text = "Level " + lv;
                        }
                        lastPlayed.text = SaveManager.getDate(2).ToString("MM/dd/yyyy hh:mm tt"); ;
                    }
                    break;
                }
            case "Save 3 Panel":
                {
                    if (PlayerDataManager.prof3 == null)
                    {
                        saveData.SetActive(false);
                    }
                    else
                    {
                        empty.SetActive(false);
                        if (PlayerDataManager.prof3.currentLevel == 4)
                            level.text = "All levels completed!";
                        else
                        {
                            int lv = PlayerDataManager.prof3.currentLevel;
                            level.text = "Level " + lv;
                        }
                        lastPlayed.text = SaveManager.getDate(3).ToString("MM/dd/yyyy hh:mm tt"); ;
                    }
                    break;
                }
            default:
                break;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Save 1 Panel":
                {
                    if (SaveManager.isNewGame)
                    {
                        SaveManager.slotNum = 1;
                        PlayerDataManager.prof1 = new PlayerData();
                        PlayerDataManager.currentProf = PlayerDataManager.prof1;
                        SaveManager.SaveData(PlayerDataManager.currentProf);
                    }
                    else
                    {
                        if (PlayerDataManager.prof1 == null)
                            return;
                        SaveManager.slotNum = 1;
                        PlayerDataManager.currentProf = PlayerDataManager.prof1;
                    }
                    break;
                }
            case "Save 2 Panel":
                {
                    if (SaveManager.isNewGame)
                    {
                        SaveManager.slotNum = 2;
                        PlayerDataManager.prof2 = new PlayerData();
                        PlayerDataManager.currentProf = PlayerDataManager.prof2;
                        SaveManager.SaveData(PlayerDataManager.currentProf);
                    }
                    else
                    {
                        if (PlayerDataManager.prof2 == null)
                            return;
                        SaveManager.slotNum = 2;
                        PlayerDataManager.currentProf = PlayerDataManager.prof2;
                    }
                    break;
                }
            case "Save 3 Panel":
                {
                    if (SaveManager.isNewGame)
                    {
                        SaveManager.slotNum = 3;
                        PlayerDataManager.prof3 = new PlayerData();
                        PlayerDataManager.currentProf = PlayerDataManager.prof3;
                        SaveManager.SaveData(PlayerDataManager.currentProf);
                    }
                    else
                    {
                        if (PlayerDataManager.prof3 == null)
                            return;
                        SaveManager.slotNum = 3;
                        PlayerDataManager.currentProf = PlayerDataManager.prof3;
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
        SceneManager.LoadScene("LevelSelect");
    }
}
