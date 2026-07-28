using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform pivot;
    public PhysicsController physics;

    public float distance = 5f;
    public float height = 2f;
    public float smoothSpeed = 8f;

    public LayerMask collisionMask;

    private Vector3 lastMoveDirection = Vector3.forward;

    void LateUpdate()
    {
        if (pivot == null || physics == null) return;

        Vector3 moveDirection = physics.GetMoveDirection();

        if (moveDirection != Vector3.zero)
        {
            lastMoveDirection = moveDirection.normalized;
        }

        Vector3 target = pivot.position + Vector3.up * height;

        Vector3 desiredPosition =
            target - lastMoveDirection * distance;

        RaycastHit hit;

        if (Physics.Linecast(
            target,
            desiredPosition,
            out hit,
            collisionMask
        ))
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

    public void SetTarget(
        Transform newPivot,
        PhysicsController newPhysics
    )
    {
        pivot = newPivot;
        physics = newPhysics;

        Vector3 moveDirection = physics.GetMoveDirection();

        if (moveDirection != Vector3.zero)
        {
            lastMoveDirection = moveDirection.normalized;
        }
    }
}