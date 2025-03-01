using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_sound : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioClip clickAudio;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SwitchAudio()
    {
        Debug.Log("Suena!");
        audioSource.PlayOneShot(hoverSound);
    }

    public void click()
    {
        audioSource.PlayOneShot(clickAudio);
    }
}
