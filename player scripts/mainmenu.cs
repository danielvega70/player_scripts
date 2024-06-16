using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    // Nombre de la escena del juego 
    public string Hangar;

    // Metodo para iniciar el juego 
    public void IniciarJuego()
    {
        // Cargar la escena del juego 
        SceneManager.LoadScene(Hangar);
    }

    // Metodo para salir del juego 
    public void SalirJuego()
    {
        // Salir de la aplicacion
        Application.Quit();
    }
}