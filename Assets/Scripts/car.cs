using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float acceleration;
    public float brake_speed;
    public bool stop;
    public Transform target;
    private Rigidbody rb;
    private bool blind = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void FixedUpdate()
    {
        
            if (stop)
            {
                rb.velocity *= brake_speed;
            }
            else
            {
                Vector3 direction = (target.position - transform.position).normalized;
                rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);
            }
     
    }

    public void SetStop(bool condition)
    {
        if (!blind)
        {
            stop = condition;
        }
    }

    //dejar ciego
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cegador"))
        {
            blind = true;
        }
    }

}
