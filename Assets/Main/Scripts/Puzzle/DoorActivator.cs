using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorActivator : MonoBehaviour
{
    [SerializeField] private PuzzleStarsManager starsManager; // Referencia al script PuzzleStarsManager
    public GameObject[] objectsToActivate;  // Objetos a activar
    public GameObject[] objectsToDeactivate;  // Objetos a desactivar



    void OnEnable()
    {
        PuzzleStarsManager.OnPuzzleStarsSolved += ActivateDoorsObjects;
        PuzzleStarsManager.OnPuzzleStarsSolved += DeactivateDoorsObjects;

    }

    void OnDisable()
    {
        PuzzleStarsManager.OnPuzzleStarsSolved -= ActivateDoorsObjects;
        PuzzleStarsManager.OnPuzzleStarsSolved -= DeactivateDoorsObjects;

    }

    void ActivateDoorsObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }

    void DeactivateDoorsObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
}
