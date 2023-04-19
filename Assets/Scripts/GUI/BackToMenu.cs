using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackToMenu : MonoBehaviour
{
    public GameObject mainMenu;

    public void returnToMenu()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
    }
}
