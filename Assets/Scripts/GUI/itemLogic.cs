using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemLogic : MonoBehaviour
{
    public InvLogic logic;
    public string itemName;

    void Awake()
    {
        logic = GameObject.Find("Inventory Canvas").GetComponent<InvLogic>();
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer==3)
        {
            Destroy(this.gameObject);
            logic.ItemPickup(itemName);
        }
    }

}
