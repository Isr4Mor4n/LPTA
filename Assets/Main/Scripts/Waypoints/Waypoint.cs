using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // La rotación que queremos aplicar al objeto cuando entre en el Waypoint
    public Vector3 nuevaRotacion;

    // Este método se llama cuando un objeto entra en el área de colisión del Waypoint
    private void OnTriggerEnter(Collider other)
    {
        // Comprobamos si el objeto que ha entrado tiene la etiqueta "Enemy"
        if (other.CompareTag("Enemy"))
        {
            // Modificamos la rotación del objeto
            other.transform.rotation = Quaternion.Euler(nuevaRotacion);
        }
    }
}
