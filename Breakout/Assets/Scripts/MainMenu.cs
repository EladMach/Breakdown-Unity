using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highScoreText;
    private AudioSource audioSource;
   

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        highScoreText.text = "HighScore: "  + PlayerPrefs.GetInt("HighScore");
    }

    public void StartGame()
    {
        audioSource.Play();
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        audioSource.Play();
        Application.Quit();
    }
    
}
