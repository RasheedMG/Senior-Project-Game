using UnityEngine;

public class PlayCrashSoundOnCollision : MonoBehaviour
{
    [SerializeField] private float velocityThresholdForSound = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > velocityThresholdForSound)
        AudioSystem.Instance.PlayEffect("Car Crash");
    }
}