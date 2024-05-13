using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsActivator : MonoBehaviour
{
    [SerializeField] private PuzzleColorManager colorManager; // Referencia al script PuzzleColorManager
    public GameObject[] objectsToActivate;  // Objetos a activar

   
    void OnEnable()
    {
        PuzzleColorManager.OnPuzzleColorSolved += ActivateStarsObjects;
    }

    void OnDisable()
    {
       PuzzleColorManager.OnPuzzleColorSolved -= ActivateStarsObjects;
    }

    void ActivateStarsObjects()
    {
        foreach (GameObject obj in objectsToActivate)
        {
            obj.SetActive(true);
        }

        /*
        if (colorManager._colorSolved == true) 
        {
            Debug.Log("Activando Estrellas");
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }

        else
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(false);
            }
        }
        */
    }
}
