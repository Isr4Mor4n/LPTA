using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JoystickMovement : MonoBehaviour
{
    Vector2 moveVector;
    [SerializeField] float moveSpeed = 8f;
    Camera currentCamera; // Cámara actual del jugador
    [SerializeField] List<Camera> associatedCameras = new List<Camera>(); // Lista de cámaras asociadas a los triggers

    [SerializeField] Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void InputPlayer(InputAction.CallbackContext _context)
    {
        moveVector = _context.ReadValue<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCamera == null)
        {
            Debug.LogError("No se ha establecido ninguna cámara actual.");
            return;
        }

        Vector3 cameraForward = currentCamera.transform.forward;
        cameraForward.y = 0f; // Asegúrate de que el vector no tenga componente Y (vertical)
        cameraForward.Normalize();

        // Transforma el vector de movimiento global al espacio de la cámara
        Vector3 movementRelativeToCamera = cameraForward * moveVector.y + currentCamera.transform.right * moveVector.x;

        movementRelativeToCamera.Normalize();
        transform.Translate(moveSpeed * movementRelativeToCamera * Time.deltaTime, Space.World);

        #region ANIMATIONS

        if (movementRelativeToCamera == Vector3.zero)
        {
            // IDLE
            _animator.SetFloat("Speed", 0);
        }
        else
        {
            _animator.SetFloat("Speed", 1);
        }

        #endregion
    }

    // Método para establecer la cámara actual del jugador
    public void SetCurrentCamera(Camera newCamera)
    {
        currentCamera = newCamera;
    }

    // Método para agregar una cámara asociada a los triggers
    public void AddAssociatedCamera(Camera camera)
    {
        associatedCameras.Add(camera);
    }

    // Método para eliminar una cámara asociada a los triggers
    public void RemoveAssociatedCamera(Camera camera)
    {
        associatedCameras.Remove(camera);
    }
}
