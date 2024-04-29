using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
    public GameObject cameraToActivate;

    public Camera associatedCamera;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraToActivate.SetActive(true);



            // Cuando el jugador entra en el trigger, busca el componente JoystickMovement y establece la cámara actual
            JoystickMovement joystickMovement = other.GetComponent<JoystickMovement>();
            if (joystickMovement != null)
            {
                joystickMovement.SetCurrentCamera(associatedCamera);
            }
            else
            {
                Debug.LogError("No se encontró el componente JoystickMovement en el jugador.");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraToActivate.SetActive(false);
        }
    }
}