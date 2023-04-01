using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] int maxHealth = 100;
    [SerializeField] int maxShield = 100;

    public int currentHealth;
    public int currentShield;


    void Start()
    {
        currentHealth = maxHealth;
        currentShield = maxShield;
    }

    void Update()
    {
        
    }

    public void TakeDamage(int amount)
    {
        int postMitigationDamage = amount;
        if (currentShield > 0)
        {
            postMitigationDamage = amount - currentShield;
            if (postMitigationDamage > 0)
            {
                currentShield = 0;
                currentHealth -= postMitigationDamage;
                if (currentHealth < 0)
                {
                    Defeated();
                }
            }
            else
            {
                currentShield -= amount;
            }
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void Defeated()
    {

    }
}
