using UnityEngine;

public class Fuego : MonoBehaviour
{
    private ParticleSystem particulaDisparo;

    void Start()
    {
        // Obtener el componente ParticleSystem adjunto al GameObject
        particulaDisparo = GetComponent<ParticleSystem>();
        // Asegurarse de que la partícula esté apagada al iniciar
        DesactivarParticula();
    }

    void Update()
    {
        // Verificar si se ha hecho clic derecho en el mouse
        if (Input.GetMouseButtonDown(1)) // 1 indica el botón derecho del mouse
        {
            // Alternar la activación de la partícula de disparo
            if (particulaDisparo.isPlaying)
            {
                DesactivarParticula();
            }
            else
            {
                ActivarParticula();
            }
        }
    }

    void ActivarParticula()
    {
        // Activar la reproducción de la partícula de disparo
        particulaDisparo.Play();
    }

    void DesactivarParticula()
    {
        // Detener la reproducción de la partícula de disparo
        particulaDisparo.Stop();
    }
}
