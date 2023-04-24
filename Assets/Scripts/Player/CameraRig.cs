using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour
{
    // camera move speed
    public float moveSpeed;

    // target object to follow
    public GameObject target;

    // transform of the camera parent
    private Transform rigTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Gets a reference to the parent Camera object's transform in the scene hierarchy
        rigTransform = this.transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // check if target exist, otherwise return
        if (target == null)
        {
            return;
        }

        // generate interpolated points between the camera position and the target and
        // smoothly move the camera on that path towards the target object
        rigTransform.position = Vector3.Lerp(rigTransform.position, target.transform.position, Time.deltaTime * moveSpeed);
    }
}
