using UnityEngine;

[System.Serializable]
public class MinimapOffset
{
    public float y = 10f;
    public float x = 0f;
    public float z = 0f;
}

public class MinimapController : MonoBehaviour
{
    [SerializeField] private Transform car;
    [SerializeField] private MinimapOffset cameraOffset;

    Vector3 newPosition;
    Quaternion newRotation;

    private void LateUpdate()
    {
        newPosition = car.position + new Vector3(cameraOffset.x, cameraOffset.y, cameraOffset.z);
        newRotation = Quaternion.Euler(90f, car.eulerAngles.y, 0f);
        transform.SetPositionAndRotation(newPosition, newRotation);
    }
}
