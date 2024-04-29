using UnityEngine;
using UnityEngine.UI;

public class PuzzleColorManager : MonoBehaviour
{
    public GameObject puzzleUI;
    public Button[] colorButtons;
    public Button closeButton;

    private int[] correctOrder = { 0, 1, 2 }; // Orden correcto de los botones de colores
    private int currentIndex = 0; // �ndice actual del bot�n que el jugador debe presionar

    private void Start()
    {
        HideUI(); // Oculta la interfaz de usuario al inicio
    }

    public void ShowUI()
    {
        puzzleUI.SetActive(true); // Muestra la interfaz de usuario

        // Asigna los m�todos de los botones
        for (int i = 0; i < colorButtons.Length; i++)
        {
            int buttonIndex = i; // Captura el �ndice para el cierre del bucle
            colorButtons[i].onClick.AddListener(() => OnColorButtonClicked(buttonIndex));
        }

        closeButton.onClick.AddListener(HideUI); // Asigna el m�todo para cerrar la UI
    }

    private void HideUI()
    {
        puzzleUI.SetActive(false); // Oculta la interfaz de usuario
    }

    private void OnColorButtonClicked(int buttonIndex)
    {
        if (buttonIndex == correctOrder[currentIndex])
        {
            currentIndex++; // Incrementa el �ndice correcto si el bot�n presionado es el correcto

            if (currentIndex >= correctOrder.Length)
            {
                // El jugador ha presionado los botones en el orden correcto
                Debug.Log("�Puzzle resuelto!");
                HideUI(); // Cierra la UI
                currentIndex = 0; // Reinicia el �ndice para el pr�ximo intento
            }
        }
        else
        {
            // El jugador ha presionado un bot�n incorrecto
            Debug.Log("�Incorrecto! Intenta de nuevo.");
            currentIndex = 0; // Reinicia el �ndice
        }
    }
}
