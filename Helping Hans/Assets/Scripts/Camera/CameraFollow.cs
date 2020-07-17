using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    public float SmoothSpeed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 fixedPosition = Target.position + offset;
        Vector3 SmoothPosition = Vector3.Lerp(transform.position, fixedPosition, SmoothSpeed);
        transform.position = SmoothPosition;
    }
}
