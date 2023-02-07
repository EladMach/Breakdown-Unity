using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

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
        restartButton.SetActive(false);
        AddScore(_score);
        UpdateLives(0);
    }

    private void Update()
    {
        lives = Mathf.Clamp(lives, 0, 10);

        scoreText.text = "Score: " + _score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        GameOver();
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

    public void GameOver()
    {
        if (lives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            restartButton.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
