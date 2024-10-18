using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ThirdPersonMove : MonoBehaviour
{
    Rigidbody rb;

    public new Transform camera;

    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Ground Check")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;

    bool grounded;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float hInput = Input.GetAxisRaw("Horizontal");
        float vInput = Input.GetAxisRaw("Vertical");

        Vector3 forwardVector = new Vector3(camera.forward.x, 0f, camera.forward.z).normalized;
        Vector3 rightVector = new Vector3(camera.right.x, 0f, camera.right.z).normalized;
        
        Vector3 moveVector = (forwardVector * vInput) + (rightVector * hInput);

        if (moveVector.magnitude > 1f)
            moveVector = moveVector.normalized;

        // Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);

        float verticalSpeed = rb.linearVelocity.y;

        if (grounded)
            // Player is able to walk
            rb.linearVelocity = new Vector3(moveVector.x, verticalSpeed, moveVector.z);
    }
}