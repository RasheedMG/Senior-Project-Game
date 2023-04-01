using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class invScript : MonoBehaviour
{
    public GameObject inv;
    public GameObject acc;

    void Start()
    {
        inv = GameObject.Find("Inventory");
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
