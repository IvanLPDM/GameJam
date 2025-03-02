using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu, levels;

    public void Start()
    {
        menu.SetActive(true);
        levels.SetActive(false);
    }

    public void Patras()
    {
        menu.SetActive(true);
        levels.SetActive(false);
    }

    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Credits(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
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
}
