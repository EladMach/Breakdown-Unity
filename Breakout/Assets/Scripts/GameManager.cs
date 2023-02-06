using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives = 5;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;

    private SpawnManager spawnManager;

    private void Start()
    { 
        spawnManager = FindObjectOfType<SpawnManager>();
    }

    private void Update()
    {
        lives = Mathf.Clamp(lives, 0, 5);
        scoreText.text = "Score: " + score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        GameOver();
    }

    public void GameOver()
    {
        if (lives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            spawnManager._stopSpawning = true;
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }
    }

}
