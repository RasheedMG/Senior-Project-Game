using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider rearLeft;
    [SerializeField] WheelCollider rearRight;

    [SerializeField] float jumpForce = 7000f;
    [SerializeField] float maxJumpTime = 0.2f;
    [SerializeField] public int maxNumberOfJumps = 1;
    [SerializeField] float jumpResetTimeout = 2f;

    [SerializeField] Transform centerOfMass;

    Rigidbody car;

    private bool pressedJump = false;
    private bool releasedJump = false;

    private bool startJumpTimer = false;
    private float currentJumpTimer;

    private bool startjumpResetTimer = false;
    private bool jumpResetTimeoutExceeded = false;
    private float currentJumpResetTimeout;


    private int jumpsAvailable;
    private bool carIsGrounded = true;

    private void Awake()
    {
        car = GetComponent<Rigidbody>();

        currentJumpTimer = maxJumpTime;

        car.centerOfMass = centerOfMass.localPosition;

        jumpsAvailable = maxNumberOfJumps;

        currentJumpResetTimeout = jumpResetTimeout;
    }

    private void Start()
    {
        maxNumberOfJumps += PlayerDataManager.currentProf.GetUpgradeCount("Chasis");
    }

    void Update()
    {
        if (startJumpTimer)
        {
            currentJumpTimer -= Time.deltaTime;
            if (currentJumpTimer <= 0)
            {
                releasedJump = true;
            }
        }

        if (startjumpResetTimer)
        {
            currentJumpResetTimeout -= Time.deltaTime;
            if (currentJumpResetTimeout <= 0)
            {
                startjumpResetTimer = false;
                jumpResetTimeoutExceeded = true;
                currentJumpResetTimeout = jumpResetTimeout;
            }
        }
    }

    private void FixedUpdate()
    {
        if (pressedJump && jumpsAvailable > 0)
        {
            jumpsAvailable--;
            StartJump();
        }

        if (releasedJump)
        {
            StopJump();
        }

        if (jumpResetTimeoutExceeded || !startJumpTimer && frontLeft.isGrounded && frontRight.isGrounded && rearLeft.isGrounded && rearRight.isGrounded)
        {
            carIsGrounded = true;
        }

        if (carIsGrounded)
        {
            pressedJump = false;
            jumpsAvailable = maxNumberOfJumps;
            jumpResetTimeoutExceeded = false;
        }
    }

    private void StartJump()
    {
        car.useGravity = false;
        car.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //Alternative Jump Function:
        //car.velocity = new Vector3(car.velocity.x, 7f, car.velocity.z);
        pressedJump = false;
        startJumpTimer = true;
        carIsGrounded = false;
        AudioSystem.Instance.PlayEffect("Jump");
    }

    private void StopJump()
    {
        car.useGravity = true;
        releasedJump = false;
        currentJumpTimer = maxJumpTime;
        startJumpTimer = false;
        startjumpResetTimer = true;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started) { pressedJump = true; }
        else if (context.canceled) { releasedJump = true; }
    }
}
