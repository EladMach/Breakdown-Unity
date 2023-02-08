using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [Header("Variables")]
    public int _score;
    public int lives = 3;

    [Header("UI Elements")]
    public GameObject restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI winText;


    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {
        DontDestroyOnLoad(this);

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        restartButton.SetActive(false);
        winText.gameObject.SetActive(false);
        winText.text = "";
        AddScore(_score);
        UpdateLives(0);
    }

    private void Update()
    {
        scoreText.text = "Score: " + _score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        GameOver();
        HighScore();
        
    }

    public void UpdateLives(int damage)
    {
        lives -= damage;
    }

    public void AddScore(int score)
    {
        _score += score;
    }
    
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void HighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < _score)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }

    public void GameOver()
    {
        if (lives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.SetActive(true);
            StopAllCoroutines();
            Time.timeScale = 0f;
        }

        if (_score == 40)
        {
            Debug.Log("You Win!");
            winText.gameObject.SetActive(true);
            restartButton.SetActive(true);
            StopAllCoroutines();
            Time.timeScale = 0f;
        }
    }

}
