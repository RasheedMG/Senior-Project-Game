using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Player's health
    public int health = 5;

    // calls enemy's attack method to attack *this* player
    void collidedWithEnemy(Enemy enemy)
    {
        // Enemy attack code
        enemy.Attack(this);
        
        if (health <= 0)
        {
            // Todo 
            Destroy(this.gameObject);
        }
    }

    // when collision happen between the enemy and the player
    void OnCollisionEnter(Collision col)
    {
        Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();

        if (enemy)
        {
            collidedWithEnemy(enemy);
        }
    }
}
