using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerActivator : MonoBehaviour
{
    public PuzzleStarsManager puzzleManager; // Referencia al PuzzleNumberManager
    public Light triggerLight; // Luz asociada al trigger
    public string sceneToLoad; // Nombre de la escena a cargar
    public GameObject puzzleNotSolvedUI; // GameObject de la interfaz de usuario para mostrar cuando el puzzle no está resuelto

    private bool puzzleSolved = false; // Estado actual del puzzle
    private bool playerInTrigger = false; // Indica si el jugador está dentro del trigger

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = true;

            // Mostrar la interfaz de usuario si el puzzle no está resuelto
            if (!puzzleSolved && puzzleNotSolvedUI != null)
            {
                puzzleNotSolvedUI.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInTrigger = false;

            // Ocultar la interfaz de usuario al salir del trigger
            if (puzzleNotSolvedUI != null)
            {
                puzzleNotSolvedUI.SetActive(false);
            }
        }
    }

    void OnPuzzleSolved()
    {
        puzzleSolved = true;
        // Cambiar color de la luz a verde si el jugador está dentro del trigger
        if (playerInTrigger)
        {
            triggerLight.color = Color.green;
        }
    }

    void Update()
    {
        // Verificar si se presionó la tecla Enter para simular la resolución del puzzle
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SimulatePuzzleSolved();
        }

        // Si el puzzle está resuelto y el jugador está en el trigger, cargar la escena
        if (puzzleSolved && playerInTrigger && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadSceneAsync("WinOver");
        }
    }

    void SimulatePuzzleSolved()
    {
        // Simular que el puzzle fue resuelto
        if (!puzzleSolved)
        {
            Debug.Log("Simulando resolución del puzzle...");
            OnPuzzleSolved();
        }
    }
}
