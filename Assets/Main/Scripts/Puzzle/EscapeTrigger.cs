using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EscapeTrigger : MonoBehaviour
{
    public string sceneToLoad; // Nombre de la escena a cargar

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadSceneAsync("WinOver");
        }
    }
}
