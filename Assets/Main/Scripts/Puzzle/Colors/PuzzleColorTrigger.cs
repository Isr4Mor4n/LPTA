using UnityEngine;

public class PuzzleColorTrigger : MonoBehaviour
{
    public PuzzleColorManager puzzleColorManager; // Referencia al Puzzle Manager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleColorManager.ShowUI(); // Llama al método ShowUI() del Puzzle Manager cuando el jugador entra en el trigger
        }
    }
}
