using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorActivator : MonoBehaviour
{
    [SerializeField] private PuzzleNumberManager numberManager; // Referencia al script PuzzleColorManager
    public GameObject[] objectsToActivate;  // Objetos a activar


    void OnEnable()
    {
        PuzzleNumberManager.OnPuzzleSolved += ActivateColorObjects;
    }

    void OnDisable()
    {
        PuzzleNumberManager.OnPuzzleSolved -= ActivateColorObjects;
    }

    void ActivateColorObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }
}
