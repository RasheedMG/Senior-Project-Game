using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class LevelLogic : MonoBehaviour, IPointerClickHandler
{
    public GameObject finished;
    public GameObject locked;
    public string level;
    public int levelNum=0;
    private int currentLevel = PlayerDataManager.currentProf.currentLevel;

    void Start()
    {
        if (currentLevel >= levelNum)
            locked.SetActive(false);
        if (currentLevel > levelNum)
            finished.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!locked.activeSelf)
            SceneManager.LoadScene(level);
    }

}
