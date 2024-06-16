using UnityEngine;

public class    armaenemigo : MonoBehaviour
{
    public Vector3 direccionDisparo; // Dirección en la que se dispara
    public float fuerzaDisparo = 10f; // Fuerza del disparo

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo
        {
            Disparar();
        }
    }

    void Disparar()
    {
        // Verificar si el componente Rigidbody está adjunto al objeto actual
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(direccionDisparo * fuerzaDisparo, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("No se encontró el componente Rigidbody en el objeto actual.");
        }
    }
}
