using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class getHP : MonoBehaviour
{
    public logicScript logic;
    private string maxHP;
    private string currentHP;
    private string initialText = "HP: ";

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
        maxHP = logic.getHP();
    }

    // Update is called once per frame
    void Update()
    {
        currentHP = logic.getHP();
        string textToShow = initialText + currentHP + "/" + maxHP;
        this.GetComponent<TextMeshProUGUI>().SetText(textToShow);
    }
}
