using UnityEngine;

public class EnemyHealthAndExplosion : MonoBehaviour
{
    public int vidaInicial = 100;
    public GameObject[] explosionPrefabs; // Array para almacenar diferentes prefabs de explosión

    private int vidaActual;

    void Start()
    {
        vidaActual = vidaInicial;
    }

    // Método para reducir la vida del enemigo
    public void ReducirVida(int cantidad)
    {
        vidaActual -= cantidad;

        // Verificar si la vida llegó a 0 o menos
        if (vidaActual <= 0)
        {
            // Obtener un índice aleatorio para seleccionar una explosión aleatoria
            int index = Random.Range(0, explosionPrefabs.Length);

            // Instanciar la explosión seleccionada
            Instantiate(explosionPrefabs[index], transform.position, Quaternion.identity);

            // Destruir el enemigo
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Bullet4"
        if (other.gameObject.tag == "Bullet4")
        {
            // Reducir la vida del enemigo cuando es impactado por el proyectil
            ReducirVida(10);

            // Destruir el proyectil
            Destroy(other.gameObject);
        }
    }
}
