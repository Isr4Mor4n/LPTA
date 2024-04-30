using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Transform cameraRotator;
    public GameObject selfCamera;

    private void OnTriggerEnter(Collider other)
    {
        selfCamera.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        selfCamera.SetActive(false);
    }
}