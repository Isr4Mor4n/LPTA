using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void BackMenu()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("Level");
    }
}