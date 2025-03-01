using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip choque, pipi, explosion, bandaSonora, sonidoAmbiental;
    public AudioSource audioSource_SFX;
    public AudioSource audioSource_BGM;
    void Start()
    {
        audioSource_SFX = GetComponent<AudioSource>();
        audioSource_BGM = GetComponent<AudioSource>();

        audioSource_BGM.PlayOneShot(bandaSonora);
        audioSource_BGM.PlayOneShot(sonidoAmbiental);
        audioSource_BGM.loop = true;
    }

    public void PlaySound(string name)
    {
        switch (name)
        {
            
                case "choque": audioSource_SFX.PlayOneShot(choque); break;
                case "pipi": audioSource_SFX.PlayOneShot(pipi); break;
                case "explosion": audioSource_SFX.PlayOneShot(explosion); break;
        }
    }

    //private void onPlay(AudioSource sc)
    //{
    //    if (!sc.isPlaying)
    //    {
    //        sc.Play();
    //    }
    //}

    public void StopSound_Bucle()
    {
        audioSource_BGM.Stop();
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
