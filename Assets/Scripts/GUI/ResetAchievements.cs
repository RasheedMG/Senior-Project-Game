using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetAchievements : MonoBehaviour
{
    public GameObject finished1;
    public GameObject finished2;
    public GameObject finished3;
    public GameObject finished4;
    public GameObject finished5;
    public GameObject finished6;

    public void reset()
    {
        finished1.SetActive(false);
        finished2.SetActive(false);
        finished3.SetActive(false);
        finished4.SetActive(false);
        finished5.SetActive(false);
        finished6.SetActive(false);

        PlayerPrefs.DeleteKey("1st Steps");
        PlayerPrefs.DeleteKey("Getting Stronger");
        PlayerPrefs.DeleteKey("Skill Issue");
        PlayerPrefs.DeleteKey("Locked and Loaded");
        PlayerPrefs.DeleteKey("The Champion");
        PlayerPrefs.DeleteKey("Versatile");
    }
}
