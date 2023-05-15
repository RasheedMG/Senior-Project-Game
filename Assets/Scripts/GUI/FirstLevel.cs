using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class FirstLevel : MonoBehaviour, IPointerClickHandler
{
    public GameObject finished;
    public string level;
    //private int currentLevel = PlayerDataManager.currentProf.currentLevel;

    void Start()
    {
        if (PlayerDataManager.currentProf.currentLevel > 1)
            finished.SetActive(true);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(level);
    }
}
