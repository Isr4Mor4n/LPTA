using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickMovement : MonoBehaviour
{
    Vector2 moveVector;
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] Camera currentCamera;
    [SerializeField] Animator _animator;
    [SerializeField] CharacterController characterController;

    void Start()
    {
        _animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    public void InputPlayer(InputAction.CallbackContext _context)
    {
        moveVector = _context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        if (currentCamera == null)
        {
            Debug.LogError("No se ha establecido ninguna cámara actual.");
            return;
        }

        if (moveVector != Vector2.zero)
        {
            // Obtener las direcciones locales de la cámara actual
            Vector3 forwardDirection = currentCamera.transform.forward;
            Vector3 rightDirection = currentCamera.transform.right;

            // Asegurar que las direcciones no tengan componente vertical
            forwardDirection.y = 0f;
            rightDirection.y = 0f;

            // Normalizar las direcciones
            forwardDirection.Normalize();
            rightDirection.Normalize();

            // Calcular el vector de movimiento local basado en las direcciones de la cámara
            Vector3 movement = forwardDirection * moveVector.y + rightDirection * moveVector.x;

            // Normalizar el vector de movimiento
            movement.Normalize();

            // Mover al jugador en la dirección local
            characterController.Move(moveSpeed * Time.fixedDeltaTime * movement);

            // Establecer la velocidad de la animación de acuerdo al movimiento
            _animator.SetFloat("Speed", 1);
        }
        else
        {
            // Si no hay entrada del joystick, detener el movimiento estableciendo la velocidad a cero
            characterController.SimpleMove(Vector3.zero);

            // Establecer la velocidad de la animación en cero
            _animator.SetFloat("Speed", 0);
        }
    }

    public void SetCurrentCamera(Camera newCamera)
    {
        currentCamera = newCamera;
    }
}
