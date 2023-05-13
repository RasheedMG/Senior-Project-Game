using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    [SerializeField] public float PlayerHealthMax = 100;
    public float PlayerHealthCurrent = 100;

    [SerializeField] public float PlayerShieldMax = 100;
    public float PlayerShieldCurrent = 100;

    [SerializeField] public float PlayerArmourMax = 10;
    public float PlayerArmourCurrent = 10;

    [SerializeField] public float shieldRegenerationRate = 2f;
    [SerializeField] public float shieldRegenerationDelay = 2f;

    private bool startRegenerationDelay = false;
    private float currentRegenerationDelay;
    private bool startRegenerating = false;



    [SerializeField] private Image Healthbar;
    [SerializeField] private Image Shieldbar;

    [SerializeField] private GameObject onDeathExplosion;
    [SerializeField] private GameObject player;

    public void Awake()
    {

        currentRegenerationDelay = shieldRegenerationDelay;
    }

    private void Update()
    {
        if (startRegenerationDelay)
        {
            currentRegenerationDelay -= Time.deltaTime;
            if (currentRegenerationDelay <= 0)
            {
                startRegenerating = true;
                startRegenerationDelay = false;
                currentRegenerationDelay = shieldRegenerationDelay;
            }
        }

        if (startRegenerating)
        {
            PlayerShieldCurrent += Time.deltaTime * shieldRegenerationRate;
            if (PlayerShieldCurrent >= PlayerShieldMax)
            {
                PlayerShieldCurrent = PlayerShieldMax;
                startRegenerating = false;
            }
            UpdateBars();
        }



    }

    public void TakeDamage(float amount)
    {
        startRegenerating = false;
        currentRegenerationDelay = shieldRegenerationDelay;
        startRegenerationDelay = true;


        float remainingDamage = amount;
        if (PlayerShieldCurrent > 0)
        {
            remainingDamage = amount - PlayerShieldCurrent;
            PlayerShieldCurrent = Mathf.Clamp(PlayerShieldCurrent - amount ,0 , 10000) ; 
        }

        if (remainingDamage > PlayerArmourCurrent)
        { 
            remainingDamage -= PlayerArmourCurrent;
        }

        else if (remainingDamage <= PlayerArmourCurrent && remainingDamage > 0) 
        {
            remainingDamage = 1;
        }

        if(remainingDamage > 0)
        {
            PlayerHealthCurrent -= remainingDamage;
        }
        if (PlayerHealthCurrent <= 0)
        {
            Defeated();
        }
        UpdateBars();
    }

 



    // To do 
    //  void shieldRestore() {}



    private void UpdateBars() 
    {
        Healthbar.fillAmount = PlayerHealthCurrent / PlayerHealthMax;
        Shieldbar.fillAmount = PlayerShieldCurrent / PlayerShieldMax;
    }


    public void Heal(float amount)
    {
        PlayerHealthCurrent += amount;
        if (PlayerHealthCurrent > PlayerHealthMax)
        {
            PlayerHealthCurrent = PlayerHealthMax;
        }
        UpdateBars();
    }

    public void MaximizeShield()
    {
        PlayerShieldCurrent = PlayerShieldMax;
        UpdateBars();
    }

    public void Defeated()
    {
        player.SetActive(false);

        AudioSystem.Instance.PlaySoundAtPoint("Car Explosion", transform.position);

        var explosion = Instantiate(onDeathExplosion, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
    }
}
