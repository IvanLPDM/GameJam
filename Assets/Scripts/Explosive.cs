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
    public ParticleSystem Explosion;
    public ParticleSystem Explosion_Vertical;
    public car carController;

    void Explode()
    {   
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            car carController = nearbyObject.GetComponent<car>();

            if (nearbyObject.CompareTag("Car"))
            {
                if (rb != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardModifier, ForceMode.Impulse);
                    carController.SetStop(true);
                    //carController.SetExplode(true);
                }
            }
        }
        carController.SetStop(true);
        //carController.SetExplode(true);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Car"))
        {
            if (uses >= 1)
            {
                Instantiate(Explosion, transform.position, Quaternion.identity).Play();
                Instantiate(Explosion_Vertical, transform.position, Quaternion.identity).Play();

                Explode();
                uses--;
            }
        }
    }
}