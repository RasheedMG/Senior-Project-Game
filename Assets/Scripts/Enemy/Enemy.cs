using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemy;

    public GameObject Player;

    public float enemyDistanceRun = 4.0f;

    [SerializeField] public float Health;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        
    }
    // Update is called once per frame
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
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            other.GetComponent<Player>().PlayerHealth -= 20;
        
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Player player = col.collider.gameObject.GetComponent<Player>();

        if (player)
        {
            player.PlayerHealth -= 20;
        }
    }


}
