using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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

    public void Levels(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
