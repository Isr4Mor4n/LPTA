using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleStarsTrigger : MonoBehaviour
{
    public PuzzleStarsManager puzzleStarsManager; // Referencia al Puzzle Manager

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            puzzleStarsManager.ShowUI(); // Llama al método ShowUI() del Puzzle Manager cuando el jugador entra en el trigger
        }
    }
}
