using UnityEngine;
using UnityEngine.UI;

public class EnergyManager : MonoBehaviour
{
    public Slider energySlider;
    public float energyLevel = 0f;
    public float maxEnergy = 100f;
    public float chargeRate = 30f;
    public float dischargeRate = 15f;
    private bool isCharging = false;

    void Start()
    {
        energySlider.maxValue = maxEnergy;
        energySlider.value = energyLevel;
    }

    void Update()
    {
        if (PauseManager.IsGamePaused)
        {
            return;
        }

        if (!isCharging)
        {
            energyLevel = Mathf.Max(energyLevel - dischargeRate * Time.deltaTime, 0);
        }

        else
        {
            energyLevel = Mathf.Min(energyLevel + chargeRate * Time.deltaTime, maxEnergy);
        }
        energySlider.value = energyLevel;
    }

    public void StartCharging()
    {
        isCharging = true;
    }

    public void StopCharging()
    {
        isCharging = false;
    }
}