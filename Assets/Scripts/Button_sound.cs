using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_sound : MonoBehaviour
{
    public AudioClip hoverSound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Suena");
        audioSource.PlayOneShot(hoverSound);

    }
}
