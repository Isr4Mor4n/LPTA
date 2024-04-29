using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public LightManager lightManager;
    public TextMeshProUGUI Timer;
    public TextMeshProUGUI BackgroundTimer;
    public TextMeshProUGUI penaltyText; // UI Text para mostrar la penalización
    public TextMeshProUGUI BackgroundpenaltyText; // UI Text para mostrar la penalización

    private float RemainingTime = 301.0f;
    private bool isRed = false;

    void Update()
    {
        if (!PauseManager.IsGamePaused && RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;
            UpdateTimerDisplay();

            if (RemainingTime <= 31 && !isRed)
            {
                lightManager.ChangeLightColors(Color.red);
                isRed = true;
            }

            if (RemainingTime <= 1)
            {
                RemainingTime = 1;
                GameOver();
            }

            // Para pruebas, aplicar la penalización con la tecla Espacio
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ApplyPenalty(10); // Penaliza 10 segundos
            }
        }
    }

    public void ApplyPenalty(float penaltyTime)
    {
        RemainingTime -= penaltyTime;
        if (RemainingTime <= 0)
        {
            RemainingTime = 0;
            GameOver();
        }
        ShowPenaltyText(penaltyTime); // Muestra el texto de la penalización
    }

    void UpdateTimerDisplay()
    {
        if (RemainingTime < 31)
        {
            Timer.color = Color.red;
        }

        int minutes = Mathf.FloorToInt(RemainingTime / 60);
        int seconds = Mathf.FloorToInt(RemainingTime % 60);

        BackgroundTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        Timer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    void ShowPenaltyText(float penaltyTime)
    {
        penaltyText.gameObject.SetActive(true);
        BackgroundpenaltyText.gameObject.SetActive(true);

        Invoke("HidePenaltyText", 1); // Ocultar texto después de 2 segundos
    }

    void HidePenaltyText()
    {
        penaltyText.gameObject.SetActive(false);
        BackgroundpenaltyText.gameObject.SetActive(false);
    }
}