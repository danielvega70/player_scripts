using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public enum ZombieState { Idle, Run, Jump }

    public float movementSpeed = 3f;
    public float followDistance = 10f;
    public float jumpForce = 5f;
    public float wanderRadius = 15f;
    public LayerMask obstacleLayerMask;

    public Animator anim;
    public Transform groundCheck;
    public float groundDistance = 0.4f;

    private NavMeshAgent zombieNav;
    private GameObject player;
    private ZombieState state = ZombieState.Idle;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("RigidBodyFPSController");
        zombieNav = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
        zombieNav.SetDestination(player.transform.position);
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case ZombieState.Run:
                if (Vector3.Distance(transform.position, player.transform.position) <= followDistance && CanSeePlayer())
                {
                    zombieNav.speed = movementSpeed;
                    zombieNav.SetDestination(player.transform.position);
                }
                else
                {
                    Wander();
                }
                break;

            case ZombieState.Idle:
                if (Vector3.Distance(transform.position, player.transform.position) <= followDistance && CanSeePlayer())
                {
                    state = ZombieState.Run;
                    anim.SetBool("isRunning", true);
                    anim.SetBool("isIdle", false);
                }
                break;

            case ZombieState.Jump:
                if (IsGrounded())
                {
                    GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    state = ZombieState.Run;
                    anim.SetBool("isJumping", false);
                    anim.SetBool("isRunning", true);
                }
                break;
        }
    }

    bool CanSeePlayer()
    {
        bool hit = Physics.Linecast(transform.position, player.transform.position, obstacleLayerMask);
        return !hit;
    }

    bool IsGrounded()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, obstacleLayerMask);
    }

    void Wander()
    {
        Vector3 randomDirection = Random.insideUnitSphere * wanderRadius;
        randomDirection += transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, wanderRadius, 1);
        Vector3 finalPosition = hit.position;
        zombieNav.SetDestination(finalPosition);
        state = ZombieState.Idle;
        anim.SetBool("isRunning", false);
        anim.SetBool("isIdle", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Hole"))
        {
            TakeDamage(maxHealth); // El enemigo se destruye al tocar un agujero
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hole"))
        {
            TakeDamage(maxHealth); // El enemigo se destruye al tocar un agujero
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
public class SeguirJugador : MonoBehaviour
{
    private Transform jugador; // Referencia al transform del jugador
    private NavMeshAgent agente; // Referencia al NavMeshAgent del enemigo

    void Start()
    {
        jugador = GameObject.FindWithTag("RigidbodyFPSController").transform; // Encontramos el transform del jugador por su etiqueta
        agente = GetComponent<NavMeshAgent>(); // Obtenemos la referencia al NavMeshAgent
    }

    void Update()
    {
        if (jugador != null) // Verificamos que el jugador exista
        {
            agente.SetDestination(jugador.position); // Establecemos la posición del jugador como destino del NavMeshAgent
        }
        else
        {
            Debug.LogWarning("¡No se encontró el jugador con la etiqueta 'RigidbodyFPSController'!");
        }
    }
}