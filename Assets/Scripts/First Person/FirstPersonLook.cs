using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class FirstPersonLook : MonoBehaviour
{
    public float sensX = 500f;
    public float sensY = 500f;

    public new Transform camera;
    public float eyeHeight = 1f;

    // Private Variables
    float xRotation;
    float yRotation;


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);
        camera.position = cameraTargetPosition;
    }

    void Update()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;  // Rotate around Y-axis (vertical) to look left/right
        xRotation -= mouseY;  // Rotate around X-axis (horizontal) to look up/down

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.eulerAngles = new Vector3(0f, yRotation, 0f);
        camera.eulerAngles = new Vector3(xRotation, yRotation, 0f);

        Vector3 cameraTargetPosition = transform.position + (Vector3.up * eyeHeight);  // Interpolating the camera avoids jittery camera movement caused by the physics engine
        camera.position = Vector3.Lerp(camera.position, cameraTargetPosition, 0.25f);
    }
}
