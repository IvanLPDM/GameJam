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
    private List<GameObject> objetos = new List<GameObject>();

    [Header("Modelos coches especiales")]
    public GameObject ferrari;
    public GameObject bomba, policia, ladron, quitaNieves, camion, fantasma, limusina;

    [Header("Configuración coches especiales")]
    public int numFerraris = 0;
    public int numBombas = 0, numPoliciasLadron = 0, numQuitaNieves = 0, numCamiones = 0, numFantasmas = 0, numLimusinas = 0;

    public int getNumCars()
    {
        return numCars;
    }

    void Start()
    {
        numNormalCars = numCars - (numFerraris + numBombas + numPoliciasLadron + numQuitaNieves + numCamiones + numFantasmas);
        StartCoroutine(Spawn());
    }

    private GameObject SelectCar()
    {

        List<GameObject> availableCars = new List<GameObject>();

        for (int i = 0; i < numNormalCars; i++) availableCars.Add(car);
        for (int i = 0; i < numFerraris; i++) availableCars.Add(ferrari);
        for (int i = 0; i < numBombas; i++) availableCars.Add(bomba);
        for (int i = 0; i < numPoliciasLadron; i++) availableCars.Add(policia);
        for (int i = 0; i < numPoliciasLadron; i++) availableCars.Add(ladron);
        for (int i = 0; i < numQuitaNieves; i++) availableCars.Add(quitaNieves);
        for (int i = 0; i < numCamiones; i++) availableCars.Add(camion);
        for (int i = 0; i < numFantasmas; i++) availableCars.Add(fantasma);
        for (int i = 0; i < numLimusinas; i++) availableCars.Add(limusina);

        if (availableCars.Count == 0)
        {
            return car;
        }

        GameObject selectedCar = availableCars[Random.Range(0, availableCars.Count)];

        if (selectedCar != car) numNormalCars--;
        else if (selectedCar == ferrari) numFerraris--;
        else if (selectedCar == bomba) numBombas--;
        else if (selectedCar == policia || selectedCar == ladron) numPoliciasLadron--;
        else if (selectedCar == quitaNieves) numQuitaNieves--;
        else if (selectedCar == camion) numCamiones--;
        else if (selectedCar == fantasma) numFantasmas--;
        else if (selectedCar == limusina) numLimusinas--;

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
                objetos.Add(carIterator);
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