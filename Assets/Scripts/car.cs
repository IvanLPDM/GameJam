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
    private bool explode = false;

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

                if(Vector3.Distance(transform.position, target.position) <= 0.5f)
                {
                    Destroy(gameObject);
                }
            }
     
    }

    public void SetStop(bool condition)
    {
        if (!blind && !explode)
        {
            stop = condition;
        }
    }

    public void SetExplode(bool condition)
    {
        explode = condition;
    }

    //dejar ciego
    

}
