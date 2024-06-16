using UnityEngine;

public class SonidoDisparo : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al AudioSource que reproducirá el sonido del disparo

    private void Start()
    {
        // Asegúrate de que el AudioSource esté asignado
        if (audioSource == null)
        {
            Debug.LogWarning("¡El AudioSource no está asignado en el script SonidoDisparo!");
        }
    }

    public void ReproducirSonidoDisparo()
    {
        if (audioSource != null)
        {
            // Reproduce el sonido del disparo si el AudioSource está asignado
            audioSource.Play();
        }
    }
}
