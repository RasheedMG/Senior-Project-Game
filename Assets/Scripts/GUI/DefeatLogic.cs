using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefeatLogic : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    public TextMeshProUGUI timer;
    public TextMeshProUGUI timeElapsed;
    public TextMeshProUGUI enemiesDefeated;
    public TextMeshProUGUI currencyGained;
    void Start()
    {
        timeElapsed.text = timeElapsed.text + timer.text;
        enemiesDefeated.text += gameManager.enemiesDefeated.ToString();
        currencyGained.text += 0.ToString();
    }

}
