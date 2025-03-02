using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ManageScene : MonoBehaviour
{
    //private List<Transform> semafaros = new List<Transform>();
    public int numCarsToLose = 16;
    public int numCarsToStar;
    private int numCars = 0;
    private int numCarsDestroyed = 0;

    //Timer
    private float startTime;  
    private float elapsedTime;

    //Quejas
    private int quejas;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI crashed_text;
    public TextMeshProUGUI quejas_txt;

    public SoundManager soundManager;

    private bool finish = false;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;

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
            elapsedTime = Time.time - startTime;

            if (timerText != null)
            {
                timerText.text = elapsedTime.ToString("F2") + " s";
                crashed_text.text = numCarsDestroyed.ToString();
                quejas_txt.text = quejas.ToString();
            }
        }

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
