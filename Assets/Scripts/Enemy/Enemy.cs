using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using LlamAcademy.Guns;
using LlamAcademy.Guns.Demo;
public class Enemy : MonoBehaviour
{
    private NavMeshAgent enemy;

    [SerializeField] public GameObject Player;
    public float EnemyDamage;
    public float enemyDistanceRun = 4.0f;
    [SerializeField] public PlayerGunSelector playergun;
    [SerializeField] public GameManager manager;
    [SerializeField]private Rigidbody rig;
    [SerializeField] public GameObject onDeathExplosion;

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

        rig.velocity = new Vector3(0f,0f,0f); ;
      

    }

    void OnCollisionEnter(Collision col)
    {
        Player player = col.collider.gameObject.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage((EnemyDamage));
        }

        Bullet bullet = col.gameObject.GetComponent<Bullet>();

        if (bullet)
        {
            Health -= playergun.ActiveGun.DamageConfig.DamageCurve.constant;
            if (Health <= 0)
            {
                manager.enemiesDefeated++;
                var explosion = Instantiate(onDeathExplosion, transform.position, Quaternion.identity);
                Destroy(explosion, 1f);

                Destroy(gameObject);


            }
        }


    }


}
