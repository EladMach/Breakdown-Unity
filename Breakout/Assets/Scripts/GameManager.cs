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
    public bool isOptions = false;
    public bool isGameOver;
    public bool isNextLevel;
    public float timer;

    [Header("UI Elements")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    
    

    [Header("GameObjects")]
    public GameObject optionsPanel;
    public GameObject nextLevelPanel;
    public GameObject gameOverPanel;
    public GameObject winText;
    public GameObject gameOverText;

    private AudioSource audioSource;

    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private void Awake()
    {

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
        isGameOver = false;
        isNextLevel = false;
        audioSource = GetComponent<AudioSource>();
        optionsPanel.SetActive(false);
        nextLevelPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        AddScore(_score);
        UpdateLives(0);
    }

    private void Update()
    {
        scoreText.text = "Score: " + _score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        GameStateContainer();
    }

    private void GameStateContainer()
    {
        GameOver();
        HighScore();
        PauseGame();
        NextLevel();
    }

    public void UpdateLives(int damage)
    {
        lives -= damage;
    }

    public void AddScore(int score)
    {
        _score += score;
    }

    public void HighScore()
    {
        if (PlayerPrefs.GetInt("HighScore") < _score)
        {
            PlayerPrefs.SetInt("HighScore", _score);
        }
    }

    

    public void TextFlicker()
    {
        timer = timer + Time.deltaTime;
        if (timer >= 0.5)
        {
            if (isNextLevel == true)
            {
                winText.gameObject.SetActive(true);
            }
            if (isGameOver == true)
            {
                gameOverText.gameObject.SetActive(true);
            }
        }
        if (timer >= 1)
        {
            if (isNextLevel == true)
            {
                winText.gameObject.SetActive(false);
            }
            if(isGameOver == true)
            {
                gameOverText.gameObject.SetActive(false);
            }
            
            timer = 0;
        }

    }

    public void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;
            isOptions = true;
            optionsPanel.SetActive(true);
        }
    }

    public void ResumeGame()
    {
        audioSource.Play();
        isOptions = false;
        Time.timeScale = 1;
        AudioListener.pause = false;
        optionsPanel.SetActive(false);
    }

    public void MainMenu()
    {
        audioSource.Play();
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        audioSource.Play();
        isOptions = false;
        AudioListener.pause = false;
        optionsPanel.SetActive(false);
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void NextLevel()
    {
        if (_score >= 20)
        {
            isNextLevel = true;
            audioSource.Play();
            TextFlicker();
            nextLevelPanel.SetActive(true);
        }
        
    }

    public void QuitGame()
    {
        audioSource.Play();
        Application.Quit();
    }

    public void GameOver()
    {
        if (lives == 0)
        {
            isGameOver = true;
            TextFlicker();
            gameOverPanel.SetActive(true);
        }
    }
}
