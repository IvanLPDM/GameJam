using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.InputManagerEntry;

public class Explosive : MonoBehaviour
{
    public float explosionForce = 1000f;  
    public float explosionRadius = 5f;   
    public float upwardModifier = 1f;
    public int uses = 1;
    public GameObject Explosion;
    public car carController;
    public AudioSource sound;

    void Start()
    {
        carController = GetComponent<car>();
    }

    void Explode()
    {
        FindObjectOfType<SoundManager>().PlaySound("explosion");

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {

            if (nearbyObject.CompareTag("Car"))
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                car carController = nearbyObject.GetComponent<car>();

                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardModifier, ForceMode.Impulse);
                    carController.SetStop(true);
                    rb.useGravity = false;
                    //carController.SetExplode(true);
                }
            }
        }
        carController.SetStop(true);
        Destroy(this.gameObject);
        //carController.SetExplode(true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Car"))
        {
            if (uses >= 1)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity);

                Explode();
                uses--;
            }
        }
    }
}