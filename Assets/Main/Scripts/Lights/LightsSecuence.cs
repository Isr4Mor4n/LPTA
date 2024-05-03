using UnityEngine;

public class SecuenciaLuces : MonoBehaviour
{
    public Light[] luces; // Array que contendrá las luces
    private int indiceActual = 0; // Índice de la luz actual en la secuencia
    private float tiempoDeCambio = 1.0f; // Duración de cada cambio de color
    private float tiempoTotal = 4.0f; // Duración total de la secuencia
    private float tiempoTranscurrido = 0.0f; // Tiempo transcurrido desde el último cambio

    private Color[] colores = { Color.white, Color.green, Color.red, Color.blue, Color.yellow }; // Colores de las luces en la secuencia

    void Start()
    {
        // Inicializar todas las luces en blanco
        foreach (Light luz in luces)
        {
            luz.color = Color.white;
        }
    }

    void Update()
    {
        // Actualizar el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Si el tiempo transcurrido es mayor o igual al tiempo total, reiniciar la secuencia
        if (tiempoTranscurrido >= tiempoTotal)
        {
            ReiniciarSecuencia();
        }
        else
        {
            // Si el tiempo transcurrido es mayor o igual al tiempo de cambio, cambiar de color
            if (tiempoTranscurrido >= tiempoDeCambio)
            {
                CambiarColor();
            }
        }
    }

    void CambiarColor()
    {
        // Cambiar el color de la luz actual al siguiente color en la secuencia
        luces[indiceActual].color = colores[indiceActual % colores.Length];

        // Restablecer el color de la luz anterior
        int indiceAnterior = (indiceActual == 0) ? luces.Length - 1 : indiceActual - 1;
        luces[indiceAnterior].color = Color.white;

        // Incrementar el índice actual
        indiceActual = (indiceActual + 1) % luces.Length;

        // Reiniciar el tiempo transcurrido
        tiempoTranscurrido = 0.0f;
    }

    void ReiniciarSecuencia()
    {
        // Reiniciar todas las luces a blanco
        foreach (Light luz in luces)
        {
            luz.color = Color.white;
        }

        // Reiniciar el índice actual y el tiempo transcurrido
        indiceActual = 0;
        tiempoTranscurrido = 0.0f;
    }
}
