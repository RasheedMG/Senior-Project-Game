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

    [SerializeField] private Image Healthbar;
    [SerializeField] private Image Shieldbar;

    [SerializeField] private GameObject onDeathExplosion;
    [SerializeField] private GameObject player;


    public void TakeDamage(int amount)
    {
        float postMitigationDamage = amount;
        if (PlayerShieldCurrent > 0)
        {
            postMitigationDamage = amount - PlayerShieldCurrent;
            if (postMitigationDamage > 0)
            {
                PlayerShieldCurrent = 0;
                PlayerHealthCurrent -= postMitigationDamage;
                if (PlayerHealthCurrent < 0)
                {
                    Defeated();
                }
            }
            else
            {
                PlayerShieldCurrent -= amount;
            }
        }
    }

    public void Heal(int amount)
    {
        PlayerHealthCurrent += amount;
        if (PlayerHealthCurrent > PlayerHealthMax)
        {
            PlayerHealthCurrent = PlayerHealthMax;
        }
    }

    public void Defeated()
    {
        Destroy(player);

        // TO DO for Rasheed ....  player death sound is here.

        var explosion = Instantiate(onDeathExplosion, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
    }




    

}
