using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] public float PlayerHealth = 100;
    [SerializeField] private GameObject onDeathExplosion;
    [SerializeField] private GameObject player;


    public void Update()
    {

        if (PlayerHealth <= 0)
        {
            Destroy(player);
            var explosion =Instantiate(onDeathExplosion, transform.position, Quaternion.identity);
            Destroy(explosion, 1f);

        }


    }

}
