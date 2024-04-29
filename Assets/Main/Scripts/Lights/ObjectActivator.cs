using UnityEngine;

public class ObjectActivator : MonoBehaviour
{
    public EnergyManager energyManager;  // Referencia al EnergyManager
    public GameObject[] objectsToActivate;  // Objetos a activar

    void OnEnable()
    {
        PuzzleNumberManager.OnPuzzleSolved += ActivateObjectsIfNeeded;
    }

    void OnDisable()
    {
        PuzzleNumberManager.OnPuzzleSolved -= ActivateObjectsIfNeeded;
    }

    void ActivateObjectsIfNeeded()
    {
        if (energyManager.energyLevel >= 50)
        {
            foreach (GameObject obj in objectsToActivate)
            {
                obj.SetActive(true);
            }
        }
    }
}
