using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _liveSprites;
    [SerializeField] private Image _LivesImg;
    

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }

    public void UpdateLives(int currentLives)
    {
        _LivesImg.sprite = _liveSprites[currentLives];
    }
}
