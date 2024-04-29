using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    public float speed = 1;
    Vector3 direction;

    bool cameraMustChange = false;
    public Transform cameraTransform;
    Transform newCameraTransform;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "cameraChanger")
        {
            other.GetComponent<CameraChanger>().Activate();
            newCameraTransform = other.GetComponent<CameraChanger>().cameraRotator;
            cameraMustChange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "cameraChanger")
        {
            other.GetComponent<CameraChanger>().Deactivate();
        }
    }

    bool anykeyPressed = false;
    // Update is called once per frame
    void Update()
    {
        direction = Vector3.zero;
        anykeyPressed = false;
        if (Input.GetKey(KeyCode.W))
        {
            anykeyPressed = true;
            direction += cameraTransform.forward;
            Debug.Log("adelante");
        }
        else if (Input.GetKey(KeyCode.S))
        {
            anykeyPressed = true;
            direction += -cameraTransform.forward;
            Debug.Log("atras");
        }
        if (Input.GetKey(KeyCode.D))
        {
            anykeyPressed = true;
            direction += cameraTransform.right;
            Debug.Log("derecha");
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anykeyPressed = true;
            direction += -cameraTransform.right;
            Debug.Log("izquierda");
        }

        if (!anykeyPressed && cameraMustChange)
        {
            cameraTransform = newCameraTransform;
            cameraMustChange = false;
            newCameraTransform = null;
        }

        cc.Move(direction.normalized * Time.deltaTime * speed);
    }
}