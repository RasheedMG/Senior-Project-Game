using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class textLogic2 : MonoBehaviour, IPointerExitHandler, IPointerClickHandler
{
    public GameObject original;
    
    void Start()
    {
        
    }


    void Update()
    {

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
        original.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SceneManager.LoadScene("TestingScene");
    }
}
