using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    [SerializeField] private GameObject uiMission; 

    void Start()
    {
        // Invoca el m�todo `Deactivate` despu�s de 20 segundos
        Invoke("Deactivate", 15f);
    }

    void Deactivate()
    {
        // Desactiva el objeto UI
        if (uiMission != null)
        {
            uiMission.SetActive(false);
        }
    }
}
