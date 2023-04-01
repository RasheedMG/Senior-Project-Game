using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnflipController : MonoBehaviour
{
    [SerializeField] float delayBeforeUnflip = 2f;
    [SerializeField] float unflipStrength = 300f;

    private float currentDelayTimer;
    private bool isFlipped = false;
    private bool flipTimerPassed = false;

    Rigidbody carRB;
    Transform carTransform;

    private void Awake()
    {
        carRB = GetComponent<Rigidbody>();
        carTransform = GetComponent<Transform>();
    }

    void Update()
    {
        //while flipped, countdown. if 0, flip timer has passed
        if (isFlipped)
        {
            currentDelayTimer -= Time.deltaTime;
            if (currentDelayTimer <= 0)
            {
                flipTimerPassed = true;
            }
        }
        else
        {
            currentDelayTimer = delayBeforeUnflip;
        }
    }

    private void FixedUpdate()
    {
        //if upside down, isflipped, else, !unflipped
        if (Vector3.Dot(transform.up, Vector3.down) > 0)
        {
            isFlipped = true;
        }
        else
        {
            isFlipped = false;
        }

        //if flip timer passed, call unflip
        if (flipTimerPassed)
        {
            Unflip();
        }
    }

    private void Unflip()
    {
        carRB.AddTorque(transform.forward * unflipStrength, ForceMode.Impulse);
        flipTimerPassed = false;
    }
}
