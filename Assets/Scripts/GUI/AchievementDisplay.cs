using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AchievementDisplay : MonoBehaviour
{
    public Achievement achievement;
    public TextMeshProUGUI title;
    public TextMeshProUGUI info;
    public GameObject finished;
    void Start()
    {
        title.text = achievement.title;
        info.text = achievement.info;
        if (PlayerPrefs.HasKey(achievement.title)&&achievement.limit==-1)
            finished.SetActive(true);
        else
        {
            if (PlayerPrefs.HasKey(achievement.title) && achievement.limit == PlayerPrefs.GetInt(achievement.title))
                finished.SetActive(true);
        }
    }
}
