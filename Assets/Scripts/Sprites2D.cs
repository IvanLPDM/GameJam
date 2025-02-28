using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites2D : MonoBehaviour
{
    public Sprite Red;
    public Sprite Green;
    public KeyCode key;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Red;
    }
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            if(spriteRenderer.sprite == Red)
                spriteRenderer.sprite = Green;
            else
                spriteRenderer.sprite = Red;
        }
    }
}
