using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityChangeCar : MonoBehaviour
{
    public car carController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            float speed = carController.GetMaxSpeed();
            float speed2 = other.GetComponent<car>().GetMaxSpeed();

            if (speed > speed2) carController.SetMaxSpeed(speed2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            carController.ResetMaxSpeed();
        }
    }
}
