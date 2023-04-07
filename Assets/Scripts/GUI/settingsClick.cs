using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class settingsClick : MonoBehaviour, IPointerClickHandler
{
    public settingsLogic logic;
    public string thisName;

        void Start()
        {
        logic = GameObject.Find("Settings Canvas").GetComponent<settingsLogic>();
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
