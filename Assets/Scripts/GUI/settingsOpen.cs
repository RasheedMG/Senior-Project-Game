using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class settingsOpen : MonoBehaviour, IPointerClickHandler, IPointerExitHandler
{

    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject original;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
        this.gameObject.SetActive(false);
        original.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
        original.SetActive(true);
    }
}
