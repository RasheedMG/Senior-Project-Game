using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendorOpen : MonoBehaviour
{
    public GameObject vendorCanvas;

    public void openVendor()
    {
        gameObject.SetActive(false);
        vendorCanvas.SetActive(true);
    }
}
