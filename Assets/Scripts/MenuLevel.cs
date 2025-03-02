using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuLevel : MonoBehaviour
{
    public GameObject lose, win, pause, ui_game;
    public AudioClip win_audio, lose_audio;
    private AudioSource audio_source;
    public ManageScene results;
    public Image time_star, cars_star, quejas_star;
    public Sprite star_win, star_lose;
    public TextMeshProUGUI time_txt, cars_txt, quejas_txt;

    void Start()
    {
        lose.SetActive(false);
        pause.SetActive(false);
        win.SetActive(false);
        ui_game.SetActive(true);
        Time.timeScale = 1.0f;
        audio_source = GetComponent<AudioSource>();
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pause.active == true)
            {
                pause.SetActive(false);
                Time.timeScale = 1.0f;
            }
            else
            {
                pause.SetActive(true);
                Time.timeScale = 0.0f;
            }
        }
    }

    public void play()
    {
        pause.SetActive(false);
        Time.timeScale = 1.0f;
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
        ui_game.SetActive(false);
        win.SetActive(true);
        audio_source.PlayOneShot(win_audio);

        if(results.numCarsDestroyed <= results.numCarsToStar)
        {
            cars_star.GetComponent<Image>().sprite = star_win;
        }
        else
            cars_star.GetComponent<Image>().sprite = star_lose;


        if (results.elapsedTime <= results.time_star)
        {
            time_star.GetComponent<Image>().sprite = star_win;
        }
        else
            time_star.GetComponent<Image>().sprite = star_lose;

        if (results.quejas <= results.quejasStar)
        {
            quejas_star.GetComponent<Image>().sprite = star_win;
        }
        else
            quejas_star.GetComponent<Image>().sprite = star_lose;


        time_txt.text = results.elapsedTime.ToString("F2") + " s";
        cars_txt.text = results.numCarsDestroyed.ToString();
        quejas_txt.text = results.quejas.ToString();
    }

}
