using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public float speed = 25;
    [SerializeField] 
    public float ProjectileDamage =10;

    public Vector3 Direction { get; set; }

 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Direction * speed * Time.deltaTime, Space.World);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision col)
    {
        Player player = col.collider.gameObject.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage((ProjectileDamage));
        }
    }

}
