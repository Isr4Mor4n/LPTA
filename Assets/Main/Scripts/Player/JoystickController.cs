using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    public Transform playerTransform; // Reference to the player's transform
    public float rotationSpeed = 5f; // Speed at which the character rotates

    private bool isDragging = false;
    private Vector2 startPosition;
    private Vector2 direction;

    public void OnPointerDown(PointerEventData eventData)
    {
        startPosition = eventData.position;
        isDragging = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        direction = (eventData.position - startPosition).normalized;
        RotatePlayer();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        direction = Vector2.zero;
    }

    private void RotatePlayer()
    {
        // Calculate the rotation angle towards the input direction
        float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        Vector3 targetDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;

        // Smoothly rotate the character towards the target direction
        playerTransform.rotation = Quaternion.Slerp(playerTransform.rotation, Quaternion.LookRotation(targetDirection), rotationSpeed * Time.deltaTime);
    }
}
