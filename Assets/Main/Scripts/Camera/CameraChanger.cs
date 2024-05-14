using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Transform _CameraRotator;
    public GameObject _SelfCamera;

    public void Activate()
    {
        _SelfCamera.SetActive(true);
    }

    public void Deactivate()
    {
        _SelfCamera.SetActive(false);
    }
}