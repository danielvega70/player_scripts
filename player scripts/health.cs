using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        // Al comienzo del juego, la salud actual es igual a la salud m�xima
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        // Resta el da�o recibido de la salud actual
        currentHealth -= damage;

        // Verifica si la salud actual es menor o igual a cero
        if (currentHealth <= 0)
        {
            // Si la salud es igual o menor a cero, el jugador muere
            Die();
        }
    }

    void Die()
    {
        // Aqu� puedes agregar cualquier l�gica que quieras cuando el jugador muere,
        // como reiniciar el nivel, mostrar un mensaje de game over, etc.
        Debug.Log("El jugador ha muerto.");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Reducir la salud del jugador en 10 cada vez que un objeto con la etiqueta "Bullet" colisione con el jugador
            TakeDamage(10);
        }
    }
}
