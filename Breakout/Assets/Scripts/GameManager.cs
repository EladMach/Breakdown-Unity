using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int _score;
    public int lives = 5;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;

    
    private void Start()
    {
        
    }

    private void Update()
    {
        lives = Mathf.Clamp(lives, 0, 5);
        scoreText.text = "Score: " + _score.ToString();
        livesText.text = "Lives: " + lives.ToString();

        GameOver();
    }

    public void GameOver()
    {
        if (lives == 0)
        {
            gameOverText.gameObject.SetActive(true);
            Time.timeScale = 0f;
            Debug.Log("Game Over");
        }
    }

    public void UpdateLives(int damage)
    {
        lives -= damage;
    }

    public void AddScore(int damage)
    {
        _score += damage;
    }
    

}
