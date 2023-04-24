using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour, IPointerClickHandler
{
    public string level;
    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene(level);
    }
}
