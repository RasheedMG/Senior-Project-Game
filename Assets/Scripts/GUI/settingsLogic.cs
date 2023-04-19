using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class settingsLogic : MonoBehaviour
{
    public GameObject gameplayPanel;
    public GameObject graphicsPanel;
    public GameObject audioPanel;
    public GameObject controlsPanel;
    public GameObject gameplayOutline;
    public GameObject graphicsOutline;
    public GameObject audioOutline;
    public GameObject controlsOutline;
    //public GameObject mainMenu;

    public void displayPanel(string name)
    {
        switch (name)
        {
            case "Gameplay":
                gameplayPanel.SetActive(true);
                gameplayOutline.SetActive(true);
                graphicsPanel.SetActive(false);
                graphicsOutline.SetActive(false);
                audioPanel.SetActive(false);
                audioOutline.SetActive(false);
                controlsPanel.SetActive(false);
                controlsOutline.SetActive(false);
                break;
            case "Graphics":
                gameplayPanel.SetActive(false);
                gameplayOutline.SetActive(false);
                graphicsPanel.SetActive(true);
                graphicsOutline.SetActive(true);
                audioPanel.SetActive(false);
                audioOutline.SetActive(false);
                controlsPanel.SetActive(false);
                controlsOutline.SetActive(false);
                break;
            case "Audio":
                gameplayPanel.SetActive(false);
                gameplayOutline.SetActive(false);
                graphicsPanel.SetActive(false);
                graphicsOutline.SetActive(false);
                audioPanel.SetActive(true);
                audioOutline.SetActive(true);
                controlsPanel.SetActive(false);
                controlsOutline.SetActive(false);
                break;
            case "Controls":
                gameplayPanel.SetActive(false);
                gameplayOutline.SetActive(false);
                graphicsPanel.SetActive(false);
                graphicsOutline.SetActive(false);
                audioPanel.SetActive(false);
                audioOutline.SetActive(false);
                controlsPanel.SetActive(true);
                controlsOutline.SetActive(true);
                break;
            default:
                break;
        }
    }
    public void saveAndExit() {
        gameplayPanel.SetActive(false);
        gameplayOutline.SetActive(false);
        graphicsPanel.SetActive(false);
        graphicsOutline.SetActive(false);
        audioPanel.SetActive(false);
        audioOutline.SetActive(false);
        controlsPanel.SetActive(false);
        controlsOutline.SetActive(false);
        this.gameObject.SetActive(false);
        //mainMenu.SetActive(true);
    }
}
