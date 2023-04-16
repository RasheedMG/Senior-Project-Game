using UnityEngine;

public class EngineSound : MonoBehaviour
{
    [SerializeField] private AudioSource engineAudioSource;

    [SerializeField] float minimumPitch;
    [SerializeField] float maximumPitch;

    private WheelController car;

    private float maximumSpeed;
    private float currentSpeed;

    private void Awake()
    {
        car = GetComponent<WheelController>();
    }

    /*private void OnEnable()
    {
        engineAudioSource.enabled = true;
    }*/

    private void Update()
    {
        maximumSpeed = car.topSpeed;
        UpdateEngineSound();
    }

    private void UpdateEngineSound()
    {
        currentSpeed = car.kmph;
        
        engineAudioSource.pitch = Mathf.Lerp(minimumPitch, maximumPitch, NormalizeSpeed(currentSpeed));
    }

    /*private void OnDisable()
    {
        engineAudioSource.enabled = false;
    }*/

    private float NormalizeSpeed(float speed)
    {
        return speed / maximumSpeed;
    }
}
