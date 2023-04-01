using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public LayerMask HitMask;
    public Vector3 Spread = new Vector3(0.1f,0.1f,0.1f);
    public float FireRate = 0.25f;

}
