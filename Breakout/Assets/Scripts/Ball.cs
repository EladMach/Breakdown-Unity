using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
   
    public float _speed = 5.0f;
    private Vector2 startingPosition;
    private Rigidbody2D rb;
    private bool isMoving = false;
    private AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false)
        {
            isMoving = true;
            rb.AddForce(Vector2.down * _speed);
        }

        if (transform.position.y < -8.5f)
        {
            isMoving = false;
            rb.velocity = Vector2.zero;
            transform.position = startingPosition;
            GameManager.Instance.SendMessageUpwards("UpdateLives", 1);

        }
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            GameManager.Instance.SendMessageUpwards("AddScore", 1);
            audioSource.Play();
            Destroy(other.gameObject); 
        }

        if (other.gameObject.CompareTag("Paddel"))
        {
            rb.velocity = new Vector2(Random.Range(-6f, 6f), 4) * _speed * Time.deltaTime;
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            audioSource.Play();
        }
    }


}
