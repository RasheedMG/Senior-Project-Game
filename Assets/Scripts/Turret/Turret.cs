using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] public TurretState currentState;

    public Transform Target { get; set; }

    

    [SerializeField]
    private float rotationSpeed;

    [SerializeField]
    private Vector3 aimOffset;
   
    [SerializeField]
    private Transform rotator;

    [SerializeField]
    private Transform ghostRotator;

    [SerializeField]
    private LayerMask layerMask;

    [SerializeField]
    private Transform[] gunBarrels;

    [SerializeField]
    private GameObject projectile;

   [SerializeField] private Animator animator;


    public Quaternion DefaultRotation { get; set; }

    public Transform Rotator { get => rotator; set => rotator = value; }
    public Vector3 AimOffset { get => aimOffset; set => aimOffset = value; }
    public Transform GhostRotator { get => ghostRotator; set => ghostRotator = value; }
    public float RotationSpeed { get => rotationSpeed; set => rotationSpeed = value; }
    public Transform[] GunBarrels { get => gunBarrels; set => gunBarrels = value; }
    public Animator Animator { get => animator; set => animator = value; }

    private void Start()
    {
        DefaultRotation = rotator.rotation;
        ChangeState(new IdleState());
    }

    private void Update()
    {
        currentState.Update();
    }

    public bool CanSeeTarget(Vector3 direction, Vector3 origin, string tag)
  {
        
        RaycastHit hit;



        if (Physics.Raycast(origin,direction, out hit, Mathf.Infinity, layerMask))
        {
            if (hit.collider.tag == tag)
            {
                return true;
            }
        }

        return false;
    }

    public void Shoot(int index)
    {
        Quaternion headingDirection = Quaternion.FromToRotation(projectile.transform.forward, GunBarrels[index].forward);

        Instantiate(projectile, GunBarrels[index].position, headingDirection).GetComponent<Projectile>().Direction = GunBarrels[index].forward;


    }
    public void ChangeState(TurretState newState)
    {
        if (newState != null)
        {
            newState.Exit();
        }
        this.currentState = newState;

        newState.Enter(this);
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.GetComponentInParent<Player>() != null)
        {
            currentState.OnTriggerEnter(other);
        }
   
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponentInParent<Player>() != null)
        {
            currentState.OnTriggerExit(other);
        }
           
    }
}
