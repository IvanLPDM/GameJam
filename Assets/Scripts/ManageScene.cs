using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScene : MonoBehaviour
{
    //private List<Transform> semafaros = new List<Transform>();
    public int numCarsToLose = 16;
    private int numCars = 0;
    private int numCarsDestroyed = 0;
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            Spawneador_coches spw = child.GetComponent<Spawneador_coches>();
            numCars += spw.getNumCars();
        }
    }

    public void CarDespawn(bool destroyed)
    {
        numCars--;
        if (destroyed) numCarsDestroyed++;
    }

    // Update is called once per frame
    void Update()
    {
        if (numCars == 0)
        {
            //WIN
            Debug.Log("HAS GANADO");
        }
        else if (numCarsDestroyed >= numCarsToLose)
        {
            //LOSE
            Debug.Log("HAS PERDIDO");
        }
        //Debug.Log(numCars);
        //Debug.Log(numCarsDestroyed);
    }
}
