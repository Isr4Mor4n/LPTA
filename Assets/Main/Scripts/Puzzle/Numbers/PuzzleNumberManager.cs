using System;
using UnityEngine;
using UnityEngine.UI;
public class PuzzleNumberManager : MonoBehaviour
{
    public GameObject puzzleUI;
    public GameObject correctUI;
    public GameObject incorrectUI;

    public Button[] numberButtons;
    public Button closeButton;
    public Countdown countdown;  // Referencia al script Countdown

    public static event Action OnPuzzleSolved;
    private int[] correctOrder = { 0, 8, 8, 4 };
    private int[] pressedOrder = new int[4];
    private int currentIndex = 0;

    private void Start()
    {
        HideUI();
    }

    public void ShowUI()
    {
        puzzleUI.SetActive(true);
        closeButton.onClick.RemoveAllListeners();
        closeButton.onClick.AddListener(HideUI);
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int buttonIndex = i;
            numberButtons[i].onClick.RemoveAllListeners();
            numberButtons[i].onClick.AddListener(() => OnNumberButtonClicked(buttonIndex));
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



    private void OnNumberButtonClicked(int buttonIndex)
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
