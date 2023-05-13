using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class itemLogic : MonoBehaviour
{
    public InvLogic logic;
    public string itemName;
    public float rotationSpeed;
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

    void Update()
    {
        if(itemName.Equals("Repair Kit"))
            transform.Rotate(Vector3.forward*rotationSpeed*Time.deltaTime);
        if (itemName.Equals("Nitrous Gas"))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        if (itemName.Equals("Mod Kit"))
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
