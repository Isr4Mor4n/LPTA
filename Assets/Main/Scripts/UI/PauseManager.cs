using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public static bool IsGamePaused = false;

    // Define eventos para la pausa y reanudación del juego
    public delegate void PauseEvent();
    public static event PauseEvent OnGamePaused;
    public static event PauseEvent OnGameResumed;

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