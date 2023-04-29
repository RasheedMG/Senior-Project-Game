using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AmmoInput : MonoBehaviour
{
    private Slider slider;
    public GameObject pricePanel;
    public TextMeshProUGUI ammoPanel;
    int limit;
    int maxAmmo;
    int currentAmmo;


    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
    }
    void Start()
    {
        int index = ammoPanel.text.IndexOf('/');
        currentAmmo = int.Parse(ammoPanel.text.Substring(0, index));
        maxAmmo = int.Parse(ammoPanel.text.Substring(index+1));
        limit = maxAmmo - currentAmmo;
        if (limit == 0)
        {
            gameObject.SetActive(false);
            pricePanel.SetActive(false);
        }
        slider.maxValue = limit;
    }

}
