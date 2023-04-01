using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getFuel : MonoBehaviour
{
    public logicScript logic;
    private string maxFuel;
    private string currentFuel;
    private string initialText = "Fuel: ";
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        maxFuel = logic.getFuel();
    }

    // Update is called once per frame
    void Update()
    {
        currentFuel = logic.getFuel();
        string textToShow = initialText + currentFuel + "/" + maxFuel;
        this.GetComponent<TextMeshProUGUI>().SetText(textToShow);
    }
}
