using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class uiLogic : MonoBehaviour
{
    public GameObject inv;
    public logicScript logicScript;
    void Start()
    {
        inv.SetActive(false);
        logicScript = GameObject.Find("Logic Manager").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inv.activeSelf == false)
            {
                inv.SetActive(true);
                logicScript.Pause();
            }
            else { 
                inv.SetActive(false);
                logicScript.Resume();
            }

            
        }

    }
    
}
