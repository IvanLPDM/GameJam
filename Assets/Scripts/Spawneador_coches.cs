using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawneador_coches : MonoBehaviour
{
    public GameObject car;
    public int numCars;
    public Transform target_;
    public Transform spawnLocation;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 3f;
    public bool space = true;

    private int spawnedCars;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while (spawnedCars < numCars)
        {
            if(space)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));

                GameObject carIterator = Instantiate(car, spawnLocation.position, spawnLocation.rotation);
                carIterator.GetComponent<car>().target = target_;
                spawnedCars++;
            }
            else
            {
                Debug.Log("NO HAY ESPACIO!!!");
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