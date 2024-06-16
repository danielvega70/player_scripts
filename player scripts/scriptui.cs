using UnityEngine;
using UnityEngine.UI;

public class  MainMenu : MonoBehaviour
{
    // Panel del men� principal
    public GameObject mainMenuPanel;

    // Panel de opciones (si tienes)
    public GameObject optionsPanel;

    // M�todo para iniciar el juego
    public void StartGame()
    {
        // Aqu� puedes cargar la escena del juego
        Debug.Log("Iniciar juego"); // Esto es solo para prop�sitos de demostraci�n
    }

    // M�todo para abrir el panel de opciones
    public void OpenOptions()
    {
        mainMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    // M�todo para volver al men� principal desde las opciones
    public void BackToMainMenu()
    {
        optionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    // M�todo para salir del juego
    public void QuitGame()
    {
        Debug.Log("Salir del juego"); // Esto es solo para prop�sitos de demostraci�n
        Application.Quit();
    }
}
