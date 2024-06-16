using UnityEngine;

public class FPSController : MonoBehaviour
{
    public Camera selectedCamera;
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacionX = 2.0f;
    public float velocidadRotacionY = 2.0f;
    public float fuerzaSalto = 5.0f;
    public bool puedeSaltar = true;

    private Rigidbody rb;
    private float rotacionX = 0.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Asegurarse de que la cámara seleccionada esté activa al inicio
        if (selectedCamera != null)
        {
            selectedCamera.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("No se ha asignado una camara en el inspector");
        }
    }

    void Update()
    {
        // Movimiento del jugador
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0.0f, movimientoVertical) * velocidadMovimiento * Time.deltaTime;
        transform.Translate(movimiento);

        // Rotación de la cámara con el ratón
        float rotacionY = Input.GetAxis("Mouse X") * velocidadRotacionX;
        rotacionX -= Input.GetAxis("Mouse Y") * velocidadRotacionY;
        rotacionX = Mathf.Clamp(rotacionX, -90.0f, 90.0f);
        transform.eulerAngles += new Vector3(0.0f, rotacionY, 0.0f);
        selectedCamera.transform.localRotation = Quaternion.Euler(rotacionX, 0.0f, 0.0f);

        // Salto del jugador
        if (puedeSaltar && Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            Debug.Log("se ha aplicado fuerza de salto.");
        }
    }

    bool IsGrounded()
    {
        RaycastHit hit;
        float distancia = GetComponent<Collider>().bounds.extents.y + 0.1f;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, distancia))
        {
            Debug.Log("El Raycast ha detecado un objeto.");
            return true;
        }
        return false;
    }
}
