using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light SpotLight;
    private float Timer;

    [SerializeField] private float MinTime;
    [SerializeField] private float MaxTime;

    private float[] intensities = { 10.0f, 1.5f, 0f };

    void Start()
    {
        Timer = Random.Range(MinTime, MaxTime);
        SpotLight.intensity = RandomIntensity();
    }

    void Update()
    {
        // Solo permite el parpadeo si el juego no está pausado
        if (!PauseManager.IsGamePaused)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                SpotLight.intensity = RandomIntensity();
                ResetTimer();
            }
        }
    }

    void LightsFlickering()
    {
        if (Timer > 0)
        {
            Timer -= Time.deltaTime;
        }

        if (Timer <= 0)
        {
            SpotLight.intensity = RandomIntensity();
            Timer = Random.Range(MinTime, MaxTime);
        }
    }

    float RandomIntensity()
    {
        return intensities[Random.Range(0, intensities.Length)];
    }

    public void ChangeColor(Color color)
    {
        SpotLight.color = color;  // Cambia el color de la luz
    }

    private void ResetTimer()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }
}