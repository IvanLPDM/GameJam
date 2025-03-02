using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desaparicion : MonoBehaviour
{
    private float timer = 5f;
    
    public void setTimer(float timer)
    {
        this.timer = timer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
