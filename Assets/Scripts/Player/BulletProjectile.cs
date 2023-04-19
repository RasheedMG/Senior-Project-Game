using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private GameObject wallVFX;
    [SerializeField] private GameObject eneVFX;
    private Rigidbody bulletRigidbody;

    //[SerializeField] private float speed = 100f;


    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            var enevfx =Instantiate(eneVFX, transform.position, Quaternion.identity);
            Destroy(enevfx, 1f);
            other.GetComponent<Enemy>().Health -= 5;
        }
        else 
        {
            var wallvfx =Instantiate(wallVFX, transform.position, Quaternion.identity);
            Destroy(wallvfx, 1f);
        }
        AudioSystem.Instance.PlaySoundAtPoint("Bullet Landing", transform.position);

        Destroy(gameObject);
    }

}
