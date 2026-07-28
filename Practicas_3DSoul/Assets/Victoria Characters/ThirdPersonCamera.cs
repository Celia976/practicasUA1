using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform pivot;
    public Transform model;

    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 8f;

    public LayerMask collisionMask;
    

    void LateUpdate()
    {
        if (pivot == null || model == null) return;

        Vector3 target = pivot.position + Vector3.up * height;
        Vector3 back = -model.up;

        Vector3 desiredPosition = target + back * distance;

        RaycastHit hit;

        if (Physics.Linecast(target, desiredPosition, out hit, collisionMask))
        {
            desiredPosition = hit.point + hit.normal * 0.2f;
        }

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed * Time.deltaTime
        );

        transform.LookAt(target);
    }
}