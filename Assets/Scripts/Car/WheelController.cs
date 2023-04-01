using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider rearLeft;
    [SerializeField] WheelCollider rearRight;

    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform rearLeftTransform;
    [SerializeField] Transform rearRightTransform;

    [SerializeField] Transform carTransform;

    [SerializeField] GameObject rightBrakelight;
    [SerializeField] GameObject leftBrakelight;

    [SerializeField] TMPro.TextMeshProUGUI speedometer;

    public Rigidbody car;

    public float acceleration = 500f;
    public float breakingForce = 30000f;
    public float maxTurnAngle = 30f;

    public const float VELOCITY_TO_KMPH_CONVERSION_RATE = 3.6f;
    public float kmph = 0;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private bool isReversing;

    private void Awake()
    {
        car = GetComponent<Rigidbody>();

        rightBrakelight.SetActive(false);
        leftBrakelight.SetActive(false);
    }

    private void Update()
    {
        speedometer.text = kmph.ToString("0");
    }

    void FixedUpdate()
    {
        // Get forward/reverse acceleration from the vertical axis (W and S keys)
        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["Forward"]))
        {
            currentAcceleration = acceleration;
            DisableBrakelightsEffect();
        }
        else if (Input.GetKey(KeybindManager.MyInstance.Keybinds["Backwards"]))
        {
            currentAcceleration = -acceleration;
            if (isReversing)
            {
                EnableBrakelightsEffect();
            }
        }
        else
        {
            currentAcceleration = 0;
        }
        //currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // If we're pressing space, give currentBreakingForce a value
        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["Brake"]))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        // Apply acceleration to front wheels
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        rearRight.motorTorque = currentAcceleration;
        rearLeft.motorTorque = currentAcceleration;

        // Apply breaking force to all wheels
        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        rearRight.brakeTorque = currentBreakForce;
        rearLeft.brakeTorque = currentBreakForce;

        // Take care of the steering
        if (Input.GetKey(KeybindManager.MyInstance.Keybinds["Left"]))
        {
            currentTurnAngle = -maxTurnAngle;
        }
        else if (Input.GetKey(KeybindManager.MyInstance.Keybinds["Right"]))
        {
            currentTurnAngle = maxTurnAngle;
        }
        else
        {
            currentTurnAngle = 0;
        }
        //currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontRight.steerAngle = currentTurnAngle;
        frontLeft.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(rearLeft, rearLeftTransform);
        UpdateWheel(rearRight, rearRightTransform);

        kmph = car.velocity.magnitude * VELOCITY_TO_KMPH_CONVERSION_RATE;

        if (Vector3.Dot(transform.forward, car.velocity) < 0)
        {
            isReversing = true;
        }
        else
        {
            isReversing = false;
        }
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        // Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        trans.rotation = rotation;
    }

    private void EnableBrakelightsEffect()
    {
        rightBrakelight.SetActive(true);
        leftBrakelight.SetActive(true);
    }

    private void DisableBrakelightsEffect()
    {
        rightBrakelight.SetActive(false);
        leftBrakelight.SetActive(false);
    }
}
