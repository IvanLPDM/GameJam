using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowStars : MonoBehaviour
{
    public int level = 1;
    public Sprite star_win, star_lose;
    public UnityEngine.UI.Image star1, star2, star3;
    
    void Awake()
    {
        int numStars = PlayerPrefs.GetInt($"Level_{level}", 0);
        star1.sprite = (numStars > 0) ? star_win : star_lose;
        star2.sprite = (numStars > 1) ? star_win : star_lose;
        star3.sprite = (numStars > 2) ? star_win : star_lose;
    }

    public void InitLevel()
    {
        SceneManager.LoadScene("Nivel_" + level);
    }
}
