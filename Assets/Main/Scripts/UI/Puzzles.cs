using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Countdown countdownTimer;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            FailInteraction();
        }
    }

    void FailInteraction()
    {
        //countdownTimer.ApplyPenalty(10f);
    }
}