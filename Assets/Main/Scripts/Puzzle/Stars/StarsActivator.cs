using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsActivator : MonoBehaviour
{
    [SerializeField] private PuzzleColorManager colorManager; // Referencia al script PuzzleColorManager
    public GameObject[] objectsToActivate;  // Objetos a activar
    public GameObject[] objectsToDeactivate;  // Objetos a desactivar


    void OnEnable()
    {
        PuzzleColorManager.OnPuzzleColorSolved += ActivateStarsObjects;
        PuzzleColorManager.OnPuzzleColorSolved += DeactivateStarsObjects;

    }

    void OnDisable()
    {
       PuzzleColorManager.OnPuzzleColorSolved -= ActivateStarsObjects;
       PuzzleColorManager.OnPuzzleColorSolved -= DeactivateStarsObjects;

    }

    void ActivateStarsObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }
    }

    void DeactivateStarsObjects()
    {
        foreach (GameObject obj in objectsToDeactivate)
        {
            obj.SetActive(false);
        }
    }
}
