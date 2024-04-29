using UnityEngine;

public class PuzzleNumberTrigger : MonoBehaviour
{
    public PuzzleNumberManager puzzleNumberManager; // Referencia al Puzzle Manager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleNumberManager.ShowUI(); // Llama al método ShowUI() del Puzzle Manager cuando el jugador entra en el trigger
        }
    }
}
