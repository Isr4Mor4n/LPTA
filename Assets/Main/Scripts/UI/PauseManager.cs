using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public static bool IsGamePaused = false;

    // Define eventos para la pausa y reanudación del juego
    public delegate void PauseEvent();
    public static event PauseEvent OnGamePaused;
    public static event PauseEvent OnGameResumed;

    private void OnEnable()
    {
        // Restablece el estado de pausa al cargar una nueva escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Restablece el estado de pausa al cargar una nueva escena
        IsGamePaused = false;
    }

    public void TogglePause()
    {
        IsGamePaused = !IsGamePaused;
        if (IsGamePaused)
        {
            // Invoca el evento de juego pausado
            OnGamePaused?.Invoke();
        }
        else
        {
            // Invoca el evento de juego reanudado
            OnGameResumed?.Invoke();
        }
    }
}
