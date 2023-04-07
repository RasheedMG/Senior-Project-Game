using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class vendorClick : MonoBehaviour, IPointerClickHandler
{
    public vendorLogic logic;
    public string thisName;

    void Start()
    {
        logic = GameObject.Find("Vendor Canvas").GetComponent<vendorLogic>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        logic.displayPanel(thisName);
    }
}
