using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class uiLogic : MonoBehaviour
{
    public GameObject inv;

    void Start()
    {

}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (inv.activeSelf == false)
                inv.SetActive(true);
            else
                inv.SetActive(false);

            
        }

    }
    
}
