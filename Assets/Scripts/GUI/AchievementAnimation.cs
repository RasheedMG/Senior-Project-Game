using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AchievementAnimation : MonoBehaviour
{
    public float moveSpeed;
    public TextMeshProUGUI title;
    public TextMeshProUGUI info;
    private bool check1 = true;
    private bool check2 = false;
    private Achievement achievement;

    void Start()
    {
        string path = "Achievements/" + gameObject.name;
        achievement = Resources.Load<Achievement>(path);
        title.text = achievement.title;
        info.text = achievement.info;
    }

    void Update()
    {
        if (transform.localPosition.y <= 450)
        {
            check1 = false;
            Invoke("rise",4);
         }

        if (check1)
            transform.position = transform.position + (Vector3.down * moveSpeed) * Time.deltaTime;
        if (check2)
        {
            if (transform.localPosition.y >= 700)
            {
                check1 = true;
                check2 = false;
                Destroy(gameObject);
            }
            transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;
        }
    }

    void rise()
    {
        check2 = true;
    }
}
