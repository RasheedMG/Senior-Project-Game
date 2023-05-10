using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemy;

    public GameObject Player;
    public float EnemyDamage;
    public float enemyDistanceRun = 4.0f;

    [SerializeField] public float Health;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance < enemyDistanceRun)
        {
            Vector3 dirToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position - dirToPlayer;
            enemy.SetDestination(newPos);
        }

        if (Health <= 0) 
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Player player = col.collider.gameObject.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage((EnemyDamage));
        }
    }


}
