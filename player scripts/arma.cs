using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma : MonoBehaviour
{
    public Transform puntoDeDisparo; // Punto desde donde se originará el raycast
    public GameObject balaPrefab; // Prefab de la bala al disparar
    public float fuerzaDisparo = 10f; // Fuerza aplicada a la bala al disparar
    public float alcanceRaycast = 100f;  // Alcance del raycast 
    public LayerMask capasObjetivo; // Capas que serán detectadas por el raycast

    public Transform armaTransform; // Transform del arma para aplicar retroceso
    public float maxRecoil = 0.5f; // Máximo valor de retroceso
    public float recoilSpeed = 2f; // Velocidad de retroceso
    private float currentRecoil = 0f; // Retroceso actual

    public int danioPorBala = 20; // Daño que hace cada bala

    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click izquierdo 
        {
            Debug.Log("Boton izquierdo del raton presionado. ");
            DispararBala();
            AplicarRetroceso();
        }
        if (Input.GetMouseButtonDown(1)) // Click derecho 
        {
            Debug.Log("Boton derecho del raton presionado.");
            DispararRayCast();
        }
    }

    void DispararBala()
    {
        Debug.Log("Disparando bala...");
        GameObject bala = Instantiate(balaPrefab, puntoDeDisparo.position, puntoDeDisparo.rotation);
        Rigidbody rb = bala.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(puntoDeDisparo.forward * fuerzaDisparo, ForceMode.Impulse);
        }
    }

    void DispararRayCast()
    {
        Debug.Log("Disparando raycast...");
        RaycastHit hit;
        if (Physics.Raycast(puntoDeDisparo.position, puntoDeDisparo.forward, out hit, alcanceRaycast, capasObjetivo))
        {
            // Si el raycast impacta un enemigo, le hace daño
            Enemy1 enemy = hit.collider.GetComponent<Enemy1>();
            if (enemy != null)
            {
                enemy.TakeDamage(danioPorBala);
            }
        }
    }

    void AplicarRetroceso()
    {
        Debug.Log("Aplicando retroceso...");
        currentRecoil += recoilSpeed;
        currentRecoil = Mathf.Clamp(currentRecoil, 0f, maxRecoil);
        armaTransform.localEulerAngles = new Vector3(0f, 0f, 0f);
    }
}
