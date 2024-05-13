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
    public static event Action OnPuzzleColorSolved;
    private int[] pressedOrder = new int[4];
    public bool _colorSolved = false;

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

    private void OnColorButtonClicked(int buttonIndex)
    {
       
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
                    OnPuzzleColorSolved?.Invoke();  // Dispara el evento
                    _colorSolved = true;
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
