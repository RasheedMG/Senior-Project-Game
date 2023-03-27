using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // move speed
    public float moveSpeed;

    // enemy health (i.e., when they should die)
    public int health;

    // the damage it can give to a player
    public int damage;

    // the target object (e.g., player)
    public Transform targetTransform;

    public void Initialize(Transform target, float moveSpeed, int health)
    {
        this.targetTransform = target;
        this.moveSpeed = moveSpeed;
        this.health = health;
    }

    void FixedUpdate()
    {
        if (targetTransform != null)
        {
            // move enemy towards to the target (Player)
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetTransform.transform.position, Time.deltaTime * moveSpeed);
        }
    }

    // Takes damage given to the enemy by a Player
    public void TakeDamage(int damage)
    {
        // updates enemy's health based on given damage
        health -= damage;

        // if the enemy health is equal or less than Zero, the enemy dies
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    // Damage player's health
    public void Attack(Player player)
    {
        player.health -= this.damage;
        //Destroy(this.gameObject);
    }   
}
