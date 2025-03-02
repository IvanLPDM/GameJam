using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawneador_coches : MonoBehaviour
{
    [Header ("Configuración general")]
    public GameObject car;
    public int numCars;
    public Transform target_;
    public Transform spawnLocation;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    public bool space = true;
    private int numNormalCars;
    private int spawnedCars;

    [Header("Modelos coches especiales")]
    public GameObject ferrari;
    public GameObject bomba, policia, ladron, quitaNieves, camion, fantasma, limusina, tren;

    [Header("Configuración coches especiales")]
    public int numFerraris = 0;
    public int numBombas = 0, numPolicias = 0, numLadrones = 0, numQuitaNieves = 0;
    public int numCamiones = 0, numFantasmas = 0, numLimusinas = 0, numTrenes = 0;

    [Header("Policia y ladron xd")]
    public int numPolicia1Spawn = 0;
    public int numLadron1Spawn = 0, numPolicia2Spawn = 0, numLadron2Spawn = 0, numPolicia3Spawn = 0, numLadron3Spawn = 0;
    public int numPolicia4Spawn = 0, numLadron4Spawn = 0, numPolicia5Spawn = 0, numLadron5Spawn = 0;

    public int getNumCars()
    {
        return numCars;
    }

    void Start()
    {
        numNormalCars = numCars - (numFerraris + numBombas + numPolicias + numLadrones 
            + numQuitaNieves + numCamiones + numFantasmas + numLimusinas + numTrenes);
        StartCoroutine(Spawn());
    }

    private GameObject SelectCar()
    {

        GameObject selectedCar;
        int siguiente = spawnedCars + 1;
        if (numPolicia1Spawn == siguiente || numPolicia2Spawn == siguiente ||
            numPolicia3Spawn == siguiente || numPolicia4Spawn == siguiente ||
            numPolicia5Spawn == siguiente) 
        {
            selectedCar = policia;
        }
        else if (numLadron1Spawn == siguiente || numLadron2Spawn == siguiente ||
            numLadron3Spawn == siguiente || numLadron4Spawn == siguiente ||
            numLadron5Spawn == siguiente) 
        { 
            selectedCar = ladron; 
        }
        else
        {
            List<GameObject> availableCars = new List<GameObject>();

            for (int i = 0; i < numNormalCars; i++) availableCars.Add(car);
            for (int i = 0; i < numFerraris; i++) availableCars.Add(ferrari);
            for (int i = 0; i < numBombas; i++) availableCars.Add(bomba);
            //for (int i = 0; i < numPolicias; i++) availableCars.Add(policia);
            //for (int i = 0; i < numLadrones; i++) availableCars.Add(ladron);
            for (int i = 0; i < numQuitaNieves; i++) availableCars.Add(quitaNieves);
            for (int i = 0; i < numCamiones; i++) availableCars.Add(camion);
            for (int i = 0; i < numFantasmas; i++) availableCars.Add(fantasma);
            for (int i = 0; i < numLimusinas; i++) availableCars.Add(limusina);
            for (int i = 0; i < numTrenes; i++) availableCars.Add(tren);

            if (availableCars.Count == 0)
            {
                return car;
            }
            selectedCar = availableCars[Random.Range(0, availableCars.Count)];
        }

        if (selectedCar != car) numNormalCars--;
        else if (selectedCar == ferrari) numFerraris--;
        else if (selectedCar == bomba) numBombas--;
        else if (selectedCar == policia) numPolicias--;
        else if (selectedCar == ladron) numLadrones--;
        else if (selectedCar == quitaNieves) numQuitaNieves--;
        else if (selectedCar == camion) numCamiones--;
        else if (selectedCar == fantasma) numFantasmas--;
        else if (selectedCar == limusina) numLimusinas--;
        else if (selectedCar == tren) numTrenes--;

        return selectedCar;
    }

    IEnumerator Spawn()
    {
        while (spawnedCars < numCars)
        {
            if(space)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

                GameObject c = SelectCar();
                GameObject carIterator = Instantiate(c, spawnLocation.position, spawnLocation.rotation);
                carIterator.GetComponent<car>().target = target_;
                spawnedCars++;
            }
            else
            {
                yield return null;
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            space = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            space = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Car"))
        {
            space = true;
        }
    }
}