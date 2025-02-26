using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Semafaro : MonoBehaviour
{
    public KeyCode key;
    public bool stop;
    public Light light;
    public Color red;
    public Color green;

    private void Update()
    {
        if(stop)
        {
            light.color = red;
        }
        else
        {
            light.color = green;
        }

        //Input
        if (Input.GetKeyDown(key))
        {
            stop = !stop;
        }
    }



    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            car carController = other.GetComponent<car>();

            if (carController != null)
            {
                carController.SetStop(stop);
            }
        }
    }
}
