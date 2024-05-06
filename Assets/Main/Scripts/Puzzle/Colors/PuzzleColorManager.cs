using System;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleColorManager : MonoBehaviour
{
    public GameObject correctUI;
    public GameObject incorrectUI;

    public GameObject puzzleUI;
    public Button[] colorButtons;
    public Button closeButton;

    public Countdown countdown;  // Referencia al script Countdown

    private int[] correctOrder = { 0, 1, 2, 3 }; // Orden correcto de los botones de colores
    private int currentIndex = 0; // Índice actual del botón que el jugador debe presionar
    public static event Action OnPuzzleSolved;
    private int[] pressedOrder = new int[4];
    

    private void Start()
    {
        HideUI(); // Oculta la interfaz de usuario al inicio
    }

    public void ShowUI()
    {
        puzzleUI.SetActive(true);
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(HideUI);
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int buttonIndex = i;
            colorButtons[i].onClick.RemoveAllListeners();
            colorButtons[i].onClick.AddListener(() => OnColorButtonClicked(buttonIndex));
        }
    }

    /*
    public void ShowUI()
    {
        puzzleUI.SetActive(true); // Muestra la interfaz de usuario

        // Asigna los métodos de los botones
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int buttonIndex = i; // Captura el índice para el cierre del bucle
            colorButtons[i].onClick.AddListener(() => OnColorButtonClicked(buttonIndex));
        }

        closeButton.onClick.AddListener(HideUI); // Asigna el método para cerrar la UI
    }
    */

    private void HideUI()
    {
        puzzleUI.SetActive(false);
        currentIndex = 0;
        pressedOrder = new int[correctOrder.Length];
    }

    public void CorrectShow()
    {
        correctUI.SetActive(true);
        Invoke(nameof(CorrectHide), 1);
    }

    public void CorrectHide()
    {
        correctUI.SetActive(false);
    }

    public void IncorrectShow()
    {
        incorrectUI.SetActive(true);
        Invoke(nameof(IncorrectHide), 1);
    }

    public void IncorrectHide()
    {
        incorrectUI.SetActive(false);
    }

    /*
    private void HideUI()
    {
        puzzleUI.SetActive(false); // Oculta la interfaz de usuario
    }
    */

    private void OnColorButtonClicked(int buttonIndex)
    {
        /*
        if (buttonIndex == correctOrder[currentIndex])
        {
            currentIndex++; // Incrementa el índice correcto si el botón presionado es el correcto

            if (currentIndex >= correctOrder.Length)
            {
                // El jugador ha presionado los botones en el orden correcto
                Debug.Log("¡Puzzle resuelto!");
                HideUI(); // Cierra la UI
                currentIndex = 0; // Reinicia el índice para el próximo intento
            }
        }
        else
        {
            // El jugador ha presionado un botón incorrecto
            Debug.Log("¡Incorrecto! Intenta de nuevo.");
            currentIndex = 0; // Reinicia el índice
        }
        */

        if (currentIndex < correctOrder.Length)
        {
            pressedOrder[currentIndex] = buttonIndex;
            currentIndex++;

            if (currentIndex == correctOrder.Length)
            {
                if (CheckCorrectOrderPressed())
                {

                    Debug.Log("¡Puzzle resuelto!");
                    CorrectShow();
                    OnPuzzleSolved?.Invoke();  // Dispara el evento
                    HideUI();
                }
                else
                {
                    Debug.Log("¡Incorrecto! Intenta de nuevo.");
                    HideUI();
                    IncorrectShow();
                    countdown.ApplyPenalty(10);
                    currentIndex = 0;
                }
            }
        }
    }

    private bool CheckCorrectOrderPressed()
    {
        for (int i = 0; i < correctOrder.Length; i++)
        {
            if (pressedOrder[i] != correctOrder[i])
            {
                return false;
            }
        }
        return true;
    }
}
