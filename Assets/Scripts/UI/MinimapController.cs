using UnityEngine;

public class MinimapController : MonoBehaviour
{
    [SerializeField] private Transform car;

    private void LateUpdate()
    {
        Vector3 newPosition = car.position;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        transform.rotation = Quaternion.Euler(90f, car.eulerAngles.y, 0f);
    }
}
