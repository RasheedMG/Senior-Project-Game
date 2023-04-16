using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class Evade : MonoBehaviour
{
    [SerializeField] float evadeStrength = 20000f;
    [SerializeField] float evadeCooldown = 3f;
    [SerializeField] float doubleClickTimeout = 0.3f;

    [SerializeField] float evadeTrailTime = 0.2f;
    [SerializeField] TrailRenderer frontLeft;
    [SerializeField] TrailRenderer frontRight;
    [SerializeField] TrailRenderer rearLeft;
    [SerializeField] TrailRenderer rearRight;

    [SerializeField] TMPro.TextMeshProUGUI evadeCooldownCounter;
    [SerializeField] Image cooldownBackgroundImage;

    Rigidbody car;


    private bool evadeAvailable = true;
    private float currentEvadeCooldownTimer;

    private bool pressedOnceA = false;
    private bool pressedTwiceA = false;
    private float currentDoubleClickTimeoutA;

    private bool pressedOnceD = false;
    private bool pressedTwiceD = false;
    private float currentDoubleClickTimeoutD;

    private float currentEvadeTrailTimer;
    private bool evadeEffectOver = true;

    private void Awake()
    {
        car = GetComponent<Rigidbody>();

        currentEvadeCooldownTimer = evadeCooldown;
        currentDoubleClickTimeoutA = doubleClickTimeout;
        currentDoubleClickTimeoutD = doubleClickTimeout;

        currentEvadeTrailTimer = evadeTrailTime;
        frontLeft.emitting = false;
        frontRight.emitting = false;
        rearLeft.emitting = false;
        rearRight.emitting = false;
    }

    void Update()
    {
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
                pressedTwiceA = false;
                pressedTwiceD = false;
                evadeAvailable = true;
                currentEvadeCooldownTimer = evadeCooldown;
            }
        }

        if (evadeAvailable)
        {
            evadeCooldownCounter.enabled = false;
            cooldownBackgroundImage.enabled = false;
        }
        else
        {
            evadeCooldownCounter.enabled = true;
            cooldownBackgroundImage.enabled = true;
        }
        evadeCooldownCounter.text = currentEvadeCooldownTimer.ToString("0.0");

        if (!evadeEffectOver)
        {
            currentEvadeTrailTimer -= Time.deltaTime;
            if (currentEvadeTrailTimer <= 0)
            {
                evadeEffectOver = true;
                currentEvadeTrailTimer = evadeTrailTime;
            }
        }
        else
        {
            frontLeft.emitting = false;
            frontRight.emitting = false;
            rearLeft.emitting = false;
            rearRight.emitting = false;
        }
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
        AudioSystem.Instance.PlayEffect("Evade");
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

        frontLeft.emitting = true;
        frontRight.emitting = true;
        rearLeft.emitting = true;
        rearRight.emitting = true;
        evadeEffectOver = false;
    }

    public void OnEvade(InputAction.CallbackContext context)
    {
        //float movement = context.ReadValue<Vector2>().x;
        float movement = context.ReadValue<float>();
        if (context.performed)
        {
            if (movement < 0)
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
            else if (movement > 0)
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
        }
    }
}
