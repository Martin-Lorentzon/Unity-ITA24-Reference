using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class FirstPersonMove : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    [Header("Ground Check")]
    public float playerHeight = 2f;
    public LayerMask whatIsGround;

    // Private Variables
    Rigidbody rb;
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
        Vector3 moveDirection = (transform.forward * vInput) + (transform.right * hInput);

        // Ground Check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.1f, whatIsGround);

        if (moveDirection.magnitude > 1f)
            moveDirection = moveDirection.normalized;  // Normalize to a length of '1' to avoid speedy diagonals

        float verticalSpeed = rb.linearVelocity.y;

        if (grounded)
            rb.linearVelocity = new Vector3(moveDirection.x * moveSpeed, verticalSpeed, moveDirection.z * moveSpeed);
    }
}
