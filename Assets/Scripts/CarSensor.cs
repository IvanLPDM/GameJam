using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSensor : MonoBehaviour
{
    public car carController; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            carController.SetStop(true);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            carController.SetStop(false);
        }
    }
}
