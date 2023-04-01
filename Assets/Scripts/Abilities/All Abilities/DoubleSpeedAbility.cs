using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DoubleSpeedAbility : Ability
{
    public float accelerationMultiplier = 2f;

    public override void Activate(GameObject parent)
    {
        //double speed
        var carWheelController = parent.GetComponent<WheelController>();
        carWheelController.acceleration *= accelerationMultiplier;
    }

    public override void Deactivate(GameObject parent)
    {
        //halve speed
        var carWheelController = parent.GetComponent<WheelController>();
        carWheelController.acceleration *= (1/accelerationMultiplier);
    }
}
