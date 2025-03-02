using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car : MonoBehaviour
{
    // Start is called before the first frame update
    [Header ("Campos obligatorios")]
    public float speed;
    public float acceleration;
    public float brake_speed;
    public float maxSpeed;
    public bool stop;
    public float maxTime = 20;
    public MeshRenderer carRenderer;
    public Material ghostMaterial;

    [Header ("Campos opcionales")]
    public bool inmortal = false;
    public Transform target;

    [Header ("Fantasma")]
    public GameObject dust;
    public bool ghost = false;
    public float ghostRadius = 5f;

    [Header ("Camion")]
    public MeshRenderer trashRenderer;

    private float timerCount;
    private float initMaxSpeed;
    private bool modoTerrorista = false;
    private Rigidbody rb;
    private BoxCollider bx;
    private bool blind = false;
    private bool explode = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        timerCount = maxTime;
        initMaxSpeed = maxSpeed;
    }

    public void Enfantasmao()
    {
        inmortal = true;
        blind = true;
        stop = false;
        modoTerrorista = true;
        maxSpeed = initMaxSpeed;
        bx.enabled = false;
        rb.useGravity = false;

        carRenderer.material = ghostMaterial;
        if (trashRenderer != null) trashRenderer.material = ghostMaterial;
    }

    private void Enfantasmar()
    {
        Enfantasmao();

        Collider[] colliders = Physics.OverlapSphere(transform.position, ghostRadius);

        foreach (Collider nearbyObject in colliders)
        {

            if (nearbyObject.CompareTag("Car"))
            {
                car carController = nearbyObject.GetComponent<car>();
                carController.Enfantasmao();
            }
        }
    }

    public bool IsGhost()
    {
        return ghost;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (inmortal) return;
        if (collision.gameObject.CompareTag("Car"))
        {
            if (ghost)
            {
                Enfantasmar();
            }
            else
            {
                if (collision.gameObject.GetComponent<car>().IsGhost()) 
                { 
                    return;
                }

                Instantiate(dust, this.transform.position, this.transform.rotation);
                FindObjectOfType<SoundManager>().PlaySound("choque");
                FindObjectOfType<ManageScene>().CarDespawn(true);
                Destroy(this.gameObject);
            }
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

    public float GetMaxSpeed()
    {
        return maxSpeed;
    }

    public void SetMaxSpeed(float speed)
    {
        if (!modoTerrorista) maxSpeed = speed;
    }

    public void ResetMaxSpeed()
    {
        maxSpeed = initMaxSpeed;
    }
}
