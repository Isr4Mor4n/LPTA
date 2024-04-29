using UnityEngine;
using System.Collections.Generic;

public class LightManager : MonoBehaviour
{
    public EnergyManager energyManager; // Referencia al EnergyManager
    public float minIntensity = 4.5f; // Intensidad mínima de las luces
    public float maxIntensity = 6.5f; // Intensidad máxima de las luces
    public float intensityChangeSpeed = 0.5f; // Velocidad de cambio de la intensidad

    [SerializeField]
    private List<Light> lights; // Lista de luces que este manager controlará
    private float timer = 1f; // Intervalo de tiempo para el parpadeo
    private bool flickering = false; // Indica si el parpadeo está activo
    private float[] intensities = { 7.5f, 4.5f }; // Nuevas intensidades para el parpadeo
    private int currentIntensityIndex = 0; // Índice para alternar entre las intensidades

    void Update()
    {
        UpdateLightIntensities();

        if (flickering)
        {
            timer -= Time.deltaTime; // Reducir el contador de tiempo
            if (timer <= 0)
            {
                // Alternar entre las intensidades
                currentIntensityIndex = (currentIntensityIndex + 1) % intensities.Length;
                foreach (Light light in lights)
                {
                    if (light != null && light.gameObject.tag != "DamagedLight")
                        light.intensity = intensities[currentIntensityIndex];
                }
                timer = 1f; // Restablecer el temporizador para el próximo parpadeo
            }
        }
    }

    public void ChangeLightColors(Color color)
    {
        foreach (Light light in lights)
        {
            if (light != null)
                light.color = color;
        }
        StartFlickering(); // Iniciar el parpadeo cuando cambie el color
    }

    private void StartFlickering()
    {
        flickering = true; // Activar el parpadeo
        timer = 1f; // Iniciar el temporizador
        currentIntensityIndex = 0; // Empezar con la primera intensidad
    }

    public void StopFlickering()
    {
        flickering = false; // Desactivar el parpadeo
        foreach (Light light in lights)
        {
            if (light != null)
                light.intensity = intensities[0]; // Establecer todas las luces a la intensidad más alta
        }
    }

    private void UpdateLightIntensities()
    {
        float targetIntensity = energyManager.energyLevel > 50 ? maxIntensity : minIntensity;

        foreach (Light light in lights)
        {
            if (light != null && light.gameObject.tag != "DamagedLight")
            {
                // Suaviza la transición de la intensidad
                light.intensity = Mathf.Lerp(light.intensity, targetIntensity, intensityChangeSpeed * Time.deltaTime);
            }
        }
    }
}
