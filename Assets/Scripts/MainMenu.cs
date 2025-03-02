using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, levels, credits;

    public void Start()
    {
        menu.SetActive(true);
        levels.SetActive(false);
    }

    public void Patras()
    {
        menu.SetActive(true);
        levels.SetActive(false);
        credits.SetActive(false);

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Credits()
    {
        menu.SetActive(false);
        levels.SetActive(false);
        credits.SetActive(true);
    }

    public void Options(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Levels()
    {
        menu.SetActive(false);
        levels.SetActive(true);
    }

    public void InitLevel(string txt)
    {
        SceneManager.LoadScene("Nivel_"+ txt);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
