using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f;
    public float maxViewingAngle = 15f; 
    public float maxDistance = 10f; 

    private Quaternion lastRotation; 
    private bool playerInView = true;

    private void Start()
    {
        lastRotation = transform.rotation;
    }

    private void Update()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, directionToPlayer); 
        float distanceToPlayer = directionToPlayer.magnitude;

        if (angleToPlayer <= maxViewingAngle && distanceToPlayer <= maxDistance)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed); 
            lastRotation = transform.rotation;
            playerInView = true; 
        }

        else if (playerInView)
        {
            transform.rotation = lastRotation;
            playerInView = false;
        }
    }
}