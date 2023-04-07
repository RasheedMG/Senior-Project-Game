using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

public class textHover : MonoBehaviour, IPointerEnterHandler
{
    public GameObject outline;
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.gameObject.SetActive(false);
        outline.SetActive(true);
    }

}
