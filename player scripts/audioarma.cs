using UnityEngine;

public class SonidoDisparo : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al AudioSource que reproducir� el sonido del disparo

    private void Start()
    {
        // Aseg�rate de que el AudioSource est� asignado
        if (audioSource == null)
        {
            Debug.LogWarning("�El AudioSource no est� asignado en el script SonidoDisparo!");
        }
    }

    public void ReproducirSonidoDisparo()
    {
        if (audioSource != null)
        {
            // Reproduce el sonido del disparo si el AudioSource est� asignado
            audioSource.Play();
        }
    }
}
