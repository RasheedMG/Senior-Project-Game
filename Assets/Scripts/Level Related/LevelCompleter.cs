using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCompleter : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private BoxCollider collider;
    [SerializeField] private MeshRenderer meshRenderer;
    
    [SerializeField] private bool requiresLever = false;

    private void Start()
    {
        if (requiresLever)
        {
            CloseExit();
        }
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
        meshRenderer.material.color = Color.green;
    }

    public void CloseExit()
    {
        collider.enabled = false;
        meshRenderer.material.color = Color.red;
    }
}
