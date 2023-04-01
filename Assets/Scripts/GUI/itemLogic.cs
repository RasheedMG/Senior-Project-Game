using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemLogic : MonoBehaviour
{
    public logicScript logic;
    public string itemName;
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer==3)
        {
            Destroy(this.gameObject);
            logic.itemPickUp(itemName);
        }
    }

}
