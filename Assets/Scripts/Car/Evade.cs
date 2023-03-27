using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Evade : MonoBehaviour
{
    [SerializeField] float evadeStrength = 10000f;
    [SerializeField] float evadeCooldown = 3f;
    [SerializeField] float doubleClickTimeout = 0.3f;

    [SerializeField] TMPro.TextMeshProUGUI evadeCooldownCounter;
    private string availableText = "Available";

    Rigidbody car;


    private bool evadeAvailable = true;
    private float currentEvadeCooldownTimer;

    private bool pressedOnceA = false;
    private bool pressedTwiceA = false;
    private float currentDoubleClickTimeoutA;

    private bool pressedOnceD = false;
    private bool pressedTwiceD = false;
    private float currentDoubleClickTimeoutD;

    private void Awake()
    {
        car = GetComponent<Rigidbody>();

        currentEvadeCooldownTimer = evadeCooldown;
        currentDoubleClickTimeoutA = doubleClickTimeout;
        currentDoubleClickTimeoutD = doubleClickTimeout;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (pressedOnceA)
            {
                pressedOnceA = false;
                pressedTwiceA = true;
            }
            else
            {
                pressedOnceA = true;
            }
            currentDoubleClickTimeoutA = doubleClickTimeout;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (pressedOnceD)
            {
                pressedOnceD = false;
                pressedTwiceD = true;
            }
            else
            {
                pressedOnceD = true;
            }
            currentDoubleClickTimeoutD = doubleClickTimeout;
        }

        if (pressedOnceA)
        {
            currentDoubleClickTimeoutA -= Time.deltaTime;
            if (currentDoubleClickTimeoutA <= 0)
            {
                pressedOnceA = false;
                currentDoubleClickTimeoutA = doubleClickTimeout;
            }
        }

        if (pressedOnceD)
        {
            currentDoubleClickTimeoutD -= Time.deltaTime;
            if (currentDoubleClickTimeoutD <= 0)
            {
                pressedOnceD = false;
                currentDoubleClickTimeoutD = doubleClickTimeout;
            }
        }

        if (!evadeAvailable)
        {
            currentEvadeCooldownTimer -= Time.deltaTime;
            if (currentEvadeCooldownTimer <= 0)
            {
                evadeAvailable = true;
                currentEvadeCooldownTimer = evadeCooldown;
            }
        }

        if (evadeAvailable)
        {
            availableText = "Available";
        }
        else
        {
            availableText = "Unavailable";
        }
        evadeCooldownCounter.text = "Evade " + availableText + ": " + currentEvadeCooldownTimer.ToString("0.00");
    }

    private void FixedUpdate()
    {
        if ((pressedTwiceA || pressedTwiceD) && evadeAvailable)
        {
            ExecuteEvade();
        }
    }

    private void ExecuteEvade()
    {
        Vector3 direction = transform.right;
        if (pressedTwiceA)
        {
            direction = transform.right * -1f;
        }

        // -- Evade function
        car.AddForce(direction * evadeStrength, ForceMode.Impulse);
        // --

        evadeAvailable = false;

        pressedTwiceA = false;
        pressedTwiceD = false;
    }
}
