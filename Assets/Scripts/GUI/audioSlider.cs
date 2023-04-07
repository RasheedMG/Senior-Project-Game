using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class audioSlider : MonoBehaviour
{
    public TextMeshProUGUI sliderText;
    public Slider slider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        sliderText.text = slider.value.ToString();
    }
}
