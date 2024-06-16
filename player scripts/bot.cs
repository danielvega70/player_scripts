using UnityEngine;
using UnityEngine.AI;

public class Bot : MonoBehaviour
{
    public Transform jugador; // Referencia al transform del jugador
    public float distanciaDeteccion = 10f; // Distancia a la que el bot detecta al jugador
    public float distanciaDisparo = 5f; // Distancia a la que el bot dispara al jugador
    public GameObject balaPrefab; // Prefab de la bala
    public Transform puntoDisparo; // Punto de origen del disparo

    private NavMeshAgent navMeshAgent;
    private bool jugadorDetectado = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        navMeshAgent.SetDestination(jugador.position);
        //Si el jugador está dentro del rango de detección
        if (!jugadorDetectado && Vector3.Distance(transform.position, jugador.position) < distanciaDeteccion)
        {
            jugadorDetectado = true;
            // Configurar el destino del NavMeshAgent al jugador
            navMeshAgent.SetDestination(jugador.position);
        }

        // Si el jugador está dentro del rango de disparo y el bot puede ver al jugador
        if (jugadorDetectado && Vector3.Distance(transform.position, jugador.position) < distanciaDisparo)
        {
            // Rotar hacia el jugador
            Vector3 direccionAlJugador = jugador.position - transform.position;
            Quaternion rotacionDeseada = Quaternion.LookRotation(direccionAlJugador);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, Time.deltaTime * navMeshAgent.angularSpeed);

            // Disparar al jugador
            Disparar();
        }
    }

    void Disparar()
    {
        // Instanciar la bala en el punto de disparo
        GameObject bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);
        // Aplicar fuerza a la bala
        bala.GetComponent<Rigidbody>().AddForce(puntoDisparo.forward * 10f, ForceMode.Impulse);
    }
}
