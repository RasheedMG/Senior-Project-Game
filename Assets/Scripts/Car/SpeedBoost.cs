using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedBoost : MonoBehaviour
{
    [SerializeField] float boostStrength = 5000f;
    [SerializeField] public float maxFuel = 5f;
    [SerializeField] float fuelRegenerationRate = 2f;
    [SerializeField] float fuelRegenerationDelay = 2f;

    [SerializeField] GameObject rightNitrous;
    [SerializeField] GameObject leftNitrous;

    [SerializeField] Slider nitroSlider;

    public Rigidbody car;

    private bool pressedBoost = false;
    private bool releasedBoost = false;

    private bool boostersEnabled = false;
    public float currentFuel;

    private bool startRegenerationDelay = false;
    private float currentRegenerationDelay;
    private bool startRegenerating = false;


    private void Awake()
    {
        car = GetComponent<Rigidbody>();

        currentFuel = maxFuel;
        currentRegenerationDelay = fuelRegenerationDelay;

        var rightNitrousParticleSystem = rightNitrous.GetComponent<ParticleSystem>().main;
        rightNitrousParticleSystem.simulationSpeed = 5f;
        var leftNitrousParticleSystem = leftNitrous.GetComponent<ParticleSystem>().main;
        leftNitrousParticleSystem.simulationSpeed = 5f;
        rightNitrous.SetActive(false);
        leftNitrous.SetActive(false);

        nitroSlider.maxValue = maxFuel;
    }

    void Update()
    {
        if (Input.GetButtonDown("Boost"))
        {
            pressedBoost = true;
        }

        if (Input.GetButtonUp("Boost"))
        {
            releasedBoost = true;
        }

        if (boostersEnabled)
        {
            startRegenerating = false;
            currentRegenerationDelay = fuelRegenerationDelay;
            currentFuel -= Time.deltaTime;
            if (currentFuel <= 0)
            {
                currentFuel = 0;
                releasedBoost = true;
            }
        }

        if (startRegenerationDelay)
        {
            currentRegenerationDelay -= Time.deltaTime;
            if (currentRegenerationDelay <= 0)
            {
                startRegenerating = true;
                startRegenerationDelay = false;
                currentRegenerationDelay = fuelRegenerationDelay;
            }
        }

        if (startRegenerating)
        {
            currentFuel += Time.deltaTime * fuelRegenerationRate;
            if (currentFuel >= maxFuel)
            {
                currentFuel = maxFuel;
                startRegenerating = false;
            }
        }

        nitroSlider.value = currentFuel;
    }

    private void FixedUpdate()
    {
        if (pressedBoost)
        {
            if (currentFuel > 0)
            {
                StartBoosters();
            }
        }

        if (releasedBoost)
        {
            StopBoosters();
            startRegenerationDelay = true;
        }
    }

    private void StartBoosters()
    {
        // -- Booster function
        car.AddForce(transform.forward.normalized * boostStrength, ForceMode.Force);
        // --
        boostersEnabled = true;
        EnableBoostersEffect();
    }

    private void StopBoosters()
    {
        pressedBoost = false;
        boostersEnabled = false;
        releasedBoost = false;
        DisableBoostersEffect();
    }

    private void EnableBoostersEffect()
    {
        rightNitrous.SetActive(true);
        leftNitrous.SetActive(true);
    }

    private void DisableBoostersEffect()
    {
        rightNitrous.SetActive(false);
        leftNitrous.SetActive(false);
    }
}
