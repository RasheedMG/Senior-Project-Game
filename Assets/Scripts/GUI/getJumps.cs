using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class getJumps : MonoBehaviour
{
    public logicScript logic;
    private string jumps;
    private string initialText = "Max Jumps: ";
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<logicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        jumps = logic.getMaxJumps();
        string textToShow = initialText + jumps;
        this.GetComponent<TextMeshProUGUI>().SetText(textToShow);
    }
}
