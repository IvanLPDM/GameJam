using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManageScene : MonoBehaviour
{
    //private List<Transform> semafaros = new List<Transform>();
    public int numCarsToLose = 16;
    private int numCars = 0;
    private int numCarsDestroyed = 0;

    public SoundManager soundManager;

    private bool finish = false;
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
        if (numCars == 0 && !finish)
        {
            //WIN
            FindObjectOfType<MenuLevel>().Win();
            Debug.Log("HAS GANADO");
            finish = true;
            soundManager.StopSound_Bucle();
        }
        else if (numCarsDestroyed >= numCarsToLose && !finish)
        {
            //LOSE
            soundManager.StopSound_Bucle();
            FindObjectOfType<MenuLevel>().Lose();
            Debug.Log("HAS PERDIDO");
            finish = true;
        }
        //Debug.Log(numCars);
        //Debug.Log(numCarsDestroyed);
    }
}
