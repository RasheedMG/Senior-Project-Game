using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SessionTimerController : MonoBehaviour
{

    public static SessionTimerController instance;

    [SerializeField] TMPro.TextMeshProUGUI timeCounter;

    public TimeSpan timePlaying;
    public bool timerRunning;

    public float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timeCounter.text = "00:00";
        timerRunning = false;

        //Since no other script calls BeginTimer(), it will be called in this file:
        BeginTimer();
    }

    public void BeginTimer()
    {
        timerRunning = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerRunning = false;
    }

    public void ResetTimer()
    {
        elapsedTime = 0f;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerRunning)
        {
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timePlayingInPlaintext = timePlaying.ToString("mm':'ss");
            timeCounter.text = timePlayingInPlaintext;

            yield return null;
        }
    }
}
