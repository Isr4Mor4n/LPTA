using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // La rotaci�n que queremos aplicar al objeto cuando entre en el Waypoint
    public Vector3 nuevaRotacion;

    // Este m�todo se llama cuando un objeto entra en el �rea de colisi�n del Waypoint
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que ha entrado tiene la etiqueta "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Modificamos la rotaci�n del objeto
            other.transform.rotation = Quaternion.Euler(nuevaRotacion);
        }
    }
}
