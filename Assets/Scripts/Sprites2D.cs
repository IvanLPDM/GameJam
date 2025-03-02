using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprites2D : MonoBehaviour
{
    public Sprite Red;
    public Sprite Green;
    public KeyCode key;
    private SpriteRenderer spriteRenderer;
    public bool on = true;
    public Color color_off;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Red;
    }
    void Update()
    {
        if (Input.GetKeyDown(key) && on)
        {
            if(spriteRenderer.sprite == Red)
                spriteRenderer.sprite = Green;
            else
                spriteRenderer.sprite = Red;
        }

        if(!on)
        {
            spriteRenderer.color = color_off;
        }
    }
}
