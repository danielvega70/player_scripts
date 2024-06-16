using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destruccion : MonoBehaviour
{
    // Variable para almacenar la salud inicial del jugador
    public int saludInicial = 100;

    // Variable para almacenar la salud actual del jugador
    private int saludActual;

    // Referencia al sistema de part�culas de la explosi�n
    public ParticleSystem explosionParticles;

    // Referencia al audio de la explosi�n
    public AudioSource explosionAudio;

    // Variable para verificar si el jugador ha sido destruido
    private bool jugadorDestruido;

    // M�todo para inicializar la salud actual al valor inicial
    void Start()
    {
        saludActual = saludInicial;
        jugadorDestruido = false;
    }

    // M�todo para detectar el impacto de una bala en el jugador
    public void RecibirImpacto(int cantidad)
    {
        // Verificar si el jugador ya ha sido destruido
        if (jugadorDestruido)
            return;

        // Restar la cantidad de da�o recibida a la salud actual
        saludActual -= cantidad;

        // Comprobar si la salud actual es menor o igual a cero
        if (saludActual <= 0)
        {
            // Si la salud es menor o igual a cero, convertir al jugador en una explosi�n de part�culas
            ConvertirEnExplosion();
        }
    }

    // M�todo para convertir al jugador en una explosi�n de part�culas
    void ConvertirEnExplosion()
    {
        // Marcar al jugador como destruido para evitar que se ejecute este m�todo nuevamente
        jugadorDestruido = true;

        // Desactivar el GameObject del jugador
        gameObject.SetActive(false);

        // Instanciar la explosi�n de part�culas en la posici�n del jugador
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        // Reproducir el sonido de la explosi�n
        explosionAudio.Play();

        // Puedes agregar cualquier otra l�gica aqu�, como reiniciar el nivel o mostrar un mensaje de juego terminado
    }
}