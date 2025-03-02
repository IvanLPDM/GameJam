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
    private float startTime;
    public float elapsedTime;
    //Quejas
    public int quejas;
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
