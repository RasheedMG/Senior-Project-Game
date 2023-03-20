using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testjump : MonoBehaviour
{

    [SerializeField] Rigidbody car;
    [SerializeField] float jumpForce = 50000f;

    [SerializeField] Rigidbody frontLeft;
    [SerializeField] Rigidbody frontRight;
    [SerializeField] Rigidbody backLeft;
    [SerializeField] Rigidbody backRight;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            car.AddForce(new Vector3(0, jumpForce, 0));
        }

        if (Input.GetKey(KeyCode.W))
        {
            car.AddForce(new Vector3(0, 0, 10000f));
        }

        if (Input.GetKey(KeyCode.S))
        {
            car.AddForce(new Vector3(0, 0, -10000f));
        }
    }
}
