using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Lever : MonoBehaviour
{
    [SerializeField] private BoxCollider collider;
    [SerializeField] private GameObject interactHUDElement;
    [SerializeField] private LeverManager leverManager;

    private bool playerIsWithinRange = false;

    private void OnEnable()
    {
        leverManager.OnLeverTrigger += Interact;
    }
    
    private void OnDisable()
    {
        leverManager.OnLeverTrigger -= Interact;
        interactHUDElement.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsWithinRange = true;
            interactHUDElement.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsWithinRange = false;
            interactHUDElement.SetActive(false);
        }
    }

    protected void Disable()
    {
        playerIsWithinRange = false;
        interactHUDElement.SetActive(false);
        collider.enabled = false;
        this.enabled = false;
    }

    public virtual void Interact() { }
}
