using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    public float speed = 1;
    Vector3 direction;

    bool cameraMustChange = false;
    public Transform cameraTransform;
    Transform newCameraTransform;

    JoystickInput controls;
    Vector2 moveInput;

    [SerializeField] Animator _animatorPlayer;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();

        // Inicializa los controles
        controls = new JoystickInput();

        // Asigna el callback para el movimiento del joystick
        controls.Movement.Input.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Movement.Input.canceled += ctx => moveInput = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.Movement.Enable();
    }

    private void OnDisable()
    {
        controls.Movement.Disable();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cameraChanger"))
        {
            other.GetComponent<CameraChanger>().Activate();
            newCameraTransform = other.GetComponent<CameraChanger>()._CameraRotator;
            cameraMustChange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("cameraChanger"))
        {
            other.GetComponent<CameraChanger>().Deactivate();
        }
    }

    void Update()
    {
        direction = Vector3.zero;
        bool anyKeyPressed = false;

        // Comprueba el input del teclado
        if (Input.GetKey(KeyCode.W))
        {
            anyKeyPressed = true;
            direction += cameraTransform.forward;
            Debug.Log("adelante");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anyKeyPressed = true;
            direction += -cameraTransform.forward;
            Debug.Log("atrás");
        }
        if (Input.GetKey(KeyCode.D))
        {
            anyKeyPressed = true;
            direction += cameraTransform.right;
            Debug.Log("derecha");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anyKeyPressed = true;
            direction += -cameraTransform.right;
            Debug.Log("izquierda");
        }

        // Si no se presionan teclas, usa el input del joystick
        if (!anyKeyPressed)
        {
            // Convierte el input del joystick a la dirección relativa de la cámara
            Vector3 joystickDirection = new Vector3(moveInput.x, 0, moveInput.y);
            joystickDirection = cameraTransform.TransformDirection(joystickDirection);

            direction += joystickDirection.normalized;

            if (moveInput.y > 0)
            {
                Debug.Log("adelante");
                _animatorPlayer.SetFloat("Speed", 1);
            }
            else if (moveInput.y < 0)
            {
                Debug.Log("atrás");
                _animatorPlayer.SetFloat("Speed", 1);
            }

            if (moveInput.y ==0)
            {
                _animatorPlayer.SetFloat("Speed", 0);
            }

            if (moveInput.x > 0)
            {
                Debug.Log("derecha");
                _animatorPlayer.SetFloat("Speed", 1);

            }
            else if (moveInput.x < 0)
            {
                Debug.Log("izquierda");
                _animatorPlayer.SetFloat("Speed", 1);

            }

            if (moveInput.x == 0)
            {
                _animatorPlayer.SetFloat("Speed", 0);
            }

        }

        // Cambia la dirección de la cámara si es necesario
        if (direction == Vector3.zero && cameraMustChange)
        {
            cameraTransform = newCameraTransform;
            cameraMustChange = false;
            newCameraTransform = null;
        }

        // Mueve el CharacterController
        cc.Move(direction * Time.deltaTime * speed);

    }
}
