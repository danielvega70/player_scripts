using UnityEngine;

public class RigidBodyFPSController : MonoBehaviour
{
    public Camera playerCamera;
    public float movementSpeed = 5.0f;
    public float rotationSpeedX = 2.0f;
    public float rotationSpeedY = 2.0f;
    public float jumpForce = 5.0f;
    private CharacterController controller;
    private float verticalRotation = 0;
    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimiento del jugador
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        moveDirection = new Vector3(sideSpeed, 0, forwardSpeed);
        moveDirection = transform.TransformDirection(moveDirection);

        // Rotación de la cámara
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeedX;
        float mouseY = -Input.GetAxis("Mouse Y") * rotationSpeedY;

        verticalRotation += mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, mouseX, 0);
        playerCamera.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        // Aplicar gravedad
        moveDirection.y -= 9.8f * Time.deltaTime;

        // Salto
        if (controller.isGrounded && Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        // Aplicar movimiento
        controller.Move(moveDirection * Time.deltaTime);
    }
}
