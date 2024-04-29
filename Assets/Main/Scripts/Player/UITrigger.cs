using UnityEngine;
using UnityEngine.UI;

public class UITrigger : MonoBehaviour
{
    public GameObject uiToActivate; // Asigna el objeto de la UI que quieres activar/desactivar
    public Button closeButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiToActivate.SetActive(true); // Activa la UI cuando el jugador entra en el trigger
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            uiToActivate.SetActive(false); // Desactiva la UI cuando el jugador entra en el trigger
        }
    }

    void Update()
    {
        closeButton.onClick.AddListener(HideUI); // Asigna el método para cerrar la UI
    }
    private void HideUI()
    {
        uiToActivate.SetActive(false); // Oculta la interfaz de usuario
    }
}