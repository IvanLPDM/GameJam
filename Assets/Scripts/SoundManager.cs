using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource choque, pipi, explosion;

    public void PlaySound(string name)
    {
        switch (name)
        {
            case "choque": onPlay(choque); break;
            case "pipi": onPlay(pipi); break;
            case "explosion": onPlay(explosion); break;
        }
    }

    private void onPlay(AudioSource sc)
    {
        if (!sc.isPlaying)
        {
            sc.Play();
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
