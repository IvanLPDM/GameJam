using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    public float acceleration;
    public float brake_speed;
    public float maxSpeed;
    public bool stop;
    public Transform target;
    public GameObject dust;
    public float maxTime = 5;
    public float timerCount;
    private Rigidbody rb;
    private bool blind = false;
    private bool explode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        timerCount = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Car"))
        {
            Instantiate(dust, this.transform.position, this.transform.rotation);
            FindObjectOfType<SoundManager>().PlaySound("choque");
            FindObjectOfType<ManageScene>().CarDespawn(true);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("cegador"))
        {
            stop = false;
            blind = true;
        }
    }

    private void Movement()
    {
        Vector3 direction = (target.position - transform.position).normalized;

        if (stop)
        {
            speed -= brake_speed;
            if (speed < 0) speed = 0;
        }
        else
        {
            speed += acceleration;
            if (speed > maxSpeed) speed = maxSpeed;
        }

        rb.MovePosition(transform.position + direction * speed * Time.fixedDeltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.5f)
        {
            FindObjectOfType<ManageScene>().CarDespawn(false);
            Destroy(gameObject);
        }
    }

    private void CounterPiPiPi()
    {
        if (stop)
        {
            timerCount -= Time.deltaTime;
            if (timerCount <= 0)
            {
                //PITA
                Debug.Log("PIPIPIPIPIPIPII");
                FindObjectOfType<SoundManager>().PlaySound("pipi");
            }
        }
        else
        {
            timerCount = maxTime;
        }
    }
    
    void FixedUpdate()
    {
        Movement();
        CounterPiPiPi();
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
