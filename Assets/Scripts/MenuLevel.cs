using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static System.Net.Mime.MediaTypeNames;

public class MenuLevel : MonoBehaviour
{
    public GameObject lose, win, pause, ui_game;
    public AudioClip win_audio, lose_audio;
    public UnityEngine.UI.Image time_star, cars_star, quejas_star, time_star_up, cars_star_up, quejas_star_up;
    public Sprite star_win, star_lose;
    public TextMeshProUGUI time_txt, cars_txt, quejas_txt;
    public TextMeshProUGUI time_win_txt, cars_win_txt, quejas_win_txt;

    private AudioSource audio_source;
    private ManageScene results;

    void Awake() //Es como el Start pero funciona mejor
    {
        lose.SetActive(false);
        pause.SetActive(false);
        win.SetActive(false);
        ui_game.SetActive(true);
        Time.timeScale = 1.0f;
        audio_source = GetComponent<AudioSource>();
        results = FindObjectOfType<ManageScene>();
    }

    private void Update()
    {
        time_txt.text = results.elapsedTime.ToString("F2") + " s";
        cars_txt.text = results.numCarsDestroyed.ToString();
        quejas_txt.text = results.quejas.ToString();

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

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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

        if(results.numCarsDestroyed <= results.numCarsToStar) cars_star.sprite = star_win;
        else cars_star.sprite = star_lose;
        cars_star_up.sprite = cars_star.sprite;

        if (results.elapsedTime <= results.time_star) time_star.sprite = star_win;
        else time_star.sprite = star_lose;
        time_star_up.sprite = time_star.sprite;

        if (results.quejas <= results.quejasStar) quejas_star.sprite = star_win;
        else quejas_star.sprite = star_lose;
        quejas_star_up.sprite = quejas_star.sprite;

        float elapsedTime = results.elapsedTime;
        int seconds = Mathf.FloorToInt(elapsedTime);
        int milliseconds = Mathf.FloorToInt((elapsedTime - seconds) * 100);

        time_win_txt.text = $"{seconds:D2}:{milliseconds:D2}";
        //time_win_txt.text = results.elapsedTime.ToString("F2") + " s";
        cars_win_txt.text = results.numCarsDestroyed.ToString();
        quejas_win_txt.text = results.quejas.ToString();
    }

}
