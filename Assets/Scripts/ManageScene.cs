using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageScene : MonoBehaviour
{
    //private List<Transform> semafaros = new List<Transform>();
    [Header("Configuracion")]
    public int numCarsToStar;
    public float time_star;
    public int quejasStar;
    public int numCarsToLose = 16;

    [Header("Info")]
    private int numCars = 0;
    public int numCarsDestroyed = 0;
    //Timer
    public float elapsedTime;
    //Quejas
    public int quejas;

    private SoundManager soundManager;
    private bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();

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

    public void Quejarse()
    {
        quejas++;
    }

    // Update is called once per frame
    void Update()
    {
        if (!finish)
        {
            elapsedTime += Time.deltaTime;
        }

        if (numCars == 0 && !finish)
        {
            //WIN
            FindObjectOfType<MenuLevel>().Win();
            finish = true;
            soundManager.StopSound_Bucle();
        }
        else if (numCarsDestroyed >= numCarsToLose && !finish)
        {
            //LOSE
            soundManager.StopSound_Bucle();
            FindObjectOfType<MenuLevel>().Lose();
            finish = true;
        }
        //Debug.Log(numCars);
        //Debug.Log(numCarsDestroyed);
    }
}
