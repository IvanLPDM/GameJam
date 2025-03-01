using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    public GameObject lose, win;

    void Start()
    {
        lose.SetActive(false);
        //win.SetActive(false);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        lose.SetActive(true);
    }

    public void Win()
    {
        win.SetActive(true);
    }
}
