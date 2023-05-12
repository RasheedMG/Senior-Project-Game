using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class WheelController : MonoBehaviour
{
    [SerializeField] private AudioSource brakeAudioSource;

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

    [SerializeField] Material BrakelightMaterial;

    [SerializeField] TMPro.TextMeshProUGUI speedometer;

    [SerializeField] float wheelRotationSmoothingFactor = 0.5f;

    [SerializeField] public Rigidbody car;

    [SerializeField] public float acceleration = 500f;
    [SerializeField] public float breakingForce = 30000f;
    [SerializeField] public float maxTurnAngle = 30f;
    [SerializeField] public float topSpeed = 150f;

    [SerializeField] private float accelerationMultiplierPerUpgrade = 3f;
    [SerializeField] private float topSpeedMultiplierPerUpgrade = 5f;

    public const float VELOCITY_TO_KMPH_CONVERSION_RATE = 3.6f;
    public float kmph = 0;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    private bool isReversing;

    Vector2 movement;

    private void Awake()
    {
        car = GetComponent<Rigidbody>();

        rightBrakelight.SetActive(false);
        leftBrakelight.SetActive(false);
    }

    private void Start()
    {
        acceleration += PlayerDataManager.currentProf.GetUpgradeCount("Power") * accelerationMultiplierPerUpgrade;
        topSpeed += PlayerDataManager.currentProf.GetUpgradeCount("Engine") * topSpeedMultiplierPerUpgrade;
    }

    private void Update()
    {
        speedometer.text = kmph.ToString("0");
    }

    void FixedUpdate()
    {
        // Get forward/reverse acceleration from the vertical axis (W and S keys)
        if (movement.y > 0)
        {
            currentAcceleration = kmph > topSpeed ? movement.y : acceleration * movement.y;
        }
        else if (movement.y < 0)
        {
            currentAcceleration = acceleration * movement.y;
        }
        else currentAcceleration = 0;

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
        currentTurnAngle = maxTurnAngle * movement.x;

        //currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontRight.steerAngle = currentTurnAngle;
        frontLeft.steerAngle = currentTurnAngle;

        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(rearLeft, rearLeftTransform);
        UpdateWheel(rearRight, rearRightTransform);

        kmph = car.velocity.magnitude * VELOCITY_TO_KMPH_CONVERSION_RATE;

        if (movement.y < 0 && Vector3.Dot(transform.forward, car.velocity) < 0)
        {
            isReversing = true;
        }
        else
        {
            isReversing = false;
            DisableReverseLight();
        }

        if (isReversing) { EnableReverseLight(); }
        else { DisableReverseLight(); }

        if (kmph < 1f)
            brakeAudioSource.Stop();
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        // Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        trans.position = position;
        //trans.rotation = rotation; < Old code, turned wheels instantly
        trans.rotation = Quaternion.Lerp(trans.rotation, rotation, wheelRotationSmoothingFactor);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void OnBrake(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            currentBreakForce = breakingForce;
            EnableBrakelightsEffect();
            if (kmph > 1)
            {
                brakeAudioSource.Play();
            }
        }
        else if (context.canceled)
        {
            currentBreakForce = 0f;
            DisableBrakelightsEffect();
            brakeAudioSource.Stop();
        }
    }

    private void EnableBrakelightsEffect()
    {
        rightBrakelight.SetActive(true);
        leftBrakelight.SetActive(true);
        BrakelightMaterial.SetColor("_EmissionColor", Color.red);
    }

    private void DisableBrakelightsEffect()
    {
        rightBrakelight.SetActive(false);
        leftBrakelight.SetActive(false);
    }

    private void EnableReverseLight()
    {
        BrakelightMaterial.SetColor("_EmissionColor", Color.white);
    }

    private void DisableReverseLight()
    {
        BrakelightMaterial.SetColor("_EmissionColor", Color.red);
    }
}
