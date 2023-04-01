using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getAcc : MonoBehaviour
{
    public logicScript logic;
    private string acc;
    private string initialText = "Acceleration: ";
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        acc = logic.getAcc();
        string textToShow = initialText + acc;
        this.GetComponent<TextMeshProUGUI>().SetText(textToShow);
    }
}
