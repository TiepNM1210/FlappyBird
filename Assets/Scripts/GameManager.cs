using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text scoreText;
    public Text timeText;
    public GameObject playButon;
    public GameObject gameOver;
    public float timeValue = 300;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }
    private void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue += 300;
        }
        DisplayTime(timeValue);
    }
    public void Play()
    {     
        score = 0;
        scoreText.text = score.ToString();
        playButon.SetActive(false);
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        player.enabled = false;
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        playButon.SetActive(true);
        Pause();
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
    }
    private void DisplayTime(float timetoDisplay)
    {
        if (timetoDisplay < 0)
        {
            timetoDisplay = 0;
        }
        float minute = Mathf.FloorToInt(timetoDisplay / 60);
        float second = Mathf.FloorToInt(timetoDisplay % 60);
        timeText.text = string.Format("{00:00}:{01:00}", minute, second);
    }
}
