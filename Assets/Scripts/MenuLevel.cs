using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLevel : MonoBehaviour
{
    public GameObject lose, win;
    public AudioClip win_audio, lose_audio;
    private AudioSource audio_source;

    void Start()
    {
        lose.SetActive(false);
        win.SetActive(false);
        audio_source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Alpha1))
        //{ 
        //    Debug.Log("space");
        //    Lose();
        //}
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextLevel(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Lose()
    {
        lose.SetActive(true);
        audio_source.PlayOneShot(lose_audio);
    }

    public void Win()
    {
        win.SetActive(true);
        audio_source.PlayOneShot(win_audio);

    }

}
