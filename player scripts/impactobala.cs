using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Variable para almacenar la salud inicial del objeto
    public int saludInicial = 100;

    // Variable para almacenar la salud actual del objeto
    private int saludActual;

    // Método para inicializar la salud actual al valor inicial
    void Start()
    {
        saludActual = saludInicial;
    }

    // Método para detectar el impacto de una bala en el objeto
    public void RecibirImpacto(int cantidad)
    {
        // Restar la cantidad de daño recibida a la salud actual
        saludActual -= cantidad;

        // Comprobar si la salud actual es menor o igual a cero
        if (saludActual <= 0)
        {
            // Si la salud es menor o igual a cero, destruir el objeto
            Destroy(gameObject);
        }
    }
}