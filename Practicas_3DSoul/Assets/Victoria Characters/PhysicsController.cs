using UnityEngine;

public class PhysicsController : MonoBehaviour
{
    public float speed = 5f;
    public Transform model;
    public float rotationSpeed = 8f;

    private Vector3 moveInput;
    private bool isWalking;

    private Quaternion initialModelRotation;

    void Start()
    {
        if (model != null)
        {
            initialModelRotation = model.rotation;
        }
    }

    void Update()
    {
        Debug.Log("Update Physics");
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ = 1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;
        if (Input.GetKey(KeyCode.S)) moveZ = -1f;

        moveInput = new Vector3(moveX, 0, moveZ).normalized;
        isWalking = moveInput != Vector3.zero;
        
        if (isWalking && model != null)
        {
            Quaternion look = Quaternion.LookRotation(moveInput);

            model.rotation = Quaternion.Slerp(
                model.rotation,
                look * initialModelRotation,
                rotationSpeed * Time.deltaTime
            );
        }
    }

    void FixedUpdate()
    {
        Debug.Log(moveInput);
        transform.position += moveInput * speed * Time.fixedDeltaTime;
    }

    public bool IsWalking()
    {
        return isWalking;
    }

    public Vector3 GetMoveDirection()
    {
        return moveInput;
    }
}