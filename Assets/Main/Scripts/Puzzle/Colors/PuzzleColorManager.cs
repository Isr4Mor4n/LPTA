using UnityEngine;
using UnityEngine.UI;

public class PuzzleColorManager : MonoBehaviour
{
    public GameObject puzzleUI;
    public Button[] colorButtons;
    public Button closeButton;

    private int[] correctOrder = { 0, 1, 2 }; // Orden correcto de los botones de colores
    private int currentIndex = 0; // Índice actual del botón que el jugador debe presionar

    private void Start()
    {
        HideUI(); // Oculta la interfaz de usuario al inicio
    }

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

    private void HideUI()
    {
        puzzleUI.SetActive(false); // Oculta la interfaz de usuario
    }

    private void OnColorButtonClicked(int buttonIndex)
    {
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
    }
}
