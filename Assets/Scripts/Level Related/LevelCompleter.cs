using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BoxCollider collider;
    
    [SerializeField] private bool requiresLever = false;

    private void Start()
    {
        collider.enabled = !requiresLever;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.levelComplete();
        }
    }

    public void OpenExit()
    {
        collider.enabled = true;
    }

    public void CloseExit()
    {
        collider.enabled = false;
    }
}
