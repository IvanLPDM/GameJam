using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queja : MonoBehaviour
{
    private float angVelocity, amp, initialPhase;

    void Start()
    {
        amp = 0.0005f;
        angVelocity = 8f;
        initialPhase = Random.Range(0, Mathf.PI * 2);
    }
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Camera.main.transform);
        Vector3 trf = transform.position;
        transform.position = new Vector3(trf.x, trf.y + amp * Mathf.Sin(angVelocity * Time.time + initialPhase), trf.z);
    }
}
