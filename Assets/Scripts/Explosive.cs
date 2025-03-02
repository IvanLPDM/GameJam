using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : MonoBehaviour
{
    public float explosionForce = 1000f;  
    public float explosionRadius = 5f;   
    public float upwardModifier = 1f;
    public int uses = 1;
    public GameObject Explosion;
    public car carController;

    private bool exploding = false;

    void Start()
    {
        carController = GetComponent<car>();
    }

    public void Explode()
    {
        if (exploding) return;
        Instantiate(Explosion, transform.position, Quaternion.identity);
        exploding = true;
        FindObjectOfType<SoundManager>().PlaySound("explosion");

        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {

            if (nearbyObject.CompareTag("Car"))
            {
                Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
                car carController = nearbyObject.GetComponent<car>();

                if (rb != null && carController != null)
                {
                    rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, upwardModifier, ForceMode.Impulse);
                    carController.SetExplode(true);
                    rb.useGravity = false;
                }
            }
        }
        carController.SetStop(true);
        Destroy(this.gameObject);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Car"))
        {
            if (uses >= 1)
            {
                Explode();
                uses--;
            }
        }
    }
}