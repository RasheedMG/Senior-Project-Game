using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SaveOrLoad : MonoBehaviour
{
    private TextMeshProUGUI title;

    void Start()
    {
        title = gameObject.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (SaveManager.isNewGame)
            title.text = "Create New Save";
        else
            title.text = "Choose Save to Load";
    }
}
