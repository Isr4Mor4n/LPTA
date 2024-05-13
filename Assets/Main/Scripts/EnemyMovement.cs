using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private CharacterController characterController;
    public float speed = 3f;
    public float minDistance = 0.1f;
    public float detectionRadius = 5f;
    public LayerMask playerLayer;
    public float attackDistance = 1.5f; // Distancia de ataque del enemigo
    public string gameOverSceneName; // Nombre de la escena de Game Over

    private Transform player;
    private bool playerDetected = false;
    private int nearestWaypointIndex;
    [SerializeField] Animator _animator;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        SetNextWaypoint();
    }

    private void Update()
    {

        if (!playerDetected)
            MoveTowardsWaypoint();
        else
            MoveTowardsNearestWaypoint();

        DetectPlayer();
        CheckPlayerProximity();
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = targetPosition - transform.position;

        if (moveDirection.magnitude <= minDistance)
        {
            SetNextWaypoint();
        }
        else
        {
            moveDirection.Normalize();
            characterController.Move(moveDirection * speed * Time.deltaTime);
            // Establecer la velocidad de la animación de acuerdo al movimiento
        }
    }

    private void MoveTowardsNearestWaypoint()
    {
        Vector3 targetPosition = waypoints[nearestWaypointIndex].position;
        Vector3 moveDirection = targetPosition - transform.position;

        if (moveDirection.magnitude <= minDistance)
        {
            // Si el jugador es detectado, permanecer en el waypoint más cercano
            return;
        }
        else
        {
            moveDirection.Normalize();
            characterController.Move(moveDirection * speed * Time.deltaTime);

        }
    }

    private void SetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
        _animator.SetFloat("WalkSpeed", 1);
    }

    private void DetectPlayer()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, detectionRadius, playerLayer);

        if (colliders.Length > 0)
        {
            player = colliders[0].transform;
            playerDetected = true;

            // Encontrar el waypoint más cercano
            float minDistance = Mathf.Infinity;
            for (int i = 0; i < waypoints.Length; i++)
            {
                float distance = Vector3.Distance(transform.position, waypoints[i].position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestWaypointIndex = i;
                }
            }
        }
        else
        {
            playerDetected = false;
        }
    }

    private void CheckPlayerProximity()
    {
        if (playerDetected)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);
            if (distanceToPlayer <= attackDistance)
            {
                // Si el jugador está demasiado cerca, eliminar al jugador y cargar la escena de Game Over
                Destroy(player.gameObject);
                SceneManager.LoadScene(gameOverSceneName);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Dibujar el radio de detección del enemigo
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);

        // Dibujar la distancia de ataque del enemigo
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, attackDistance);
    }
}
