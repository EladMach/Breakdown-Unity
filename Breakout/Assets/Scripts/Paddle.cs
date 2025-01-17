using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [Header("Variables")]
    public float _movementSpeed = 10f;

    private AudioSource audioSource;

    private void Start()
    {     
        audioSource = GetComponent<AudioSource>();
    }
    
    void Update()
    {
        CalculateMovment();
    }

    void CalculateMovment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector2(horizontalInput, 0);    

        transform.Translate(direction * _movementSpeed * Time.deltaTime);

        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -7.0f, 7.0f), Mathf.Clamp(transform.position.y, -4.7f, 0));
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        { 
            audioSource.Play();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy1"))
        {
            GameManager.Instance.SendMessageUpwards("UpdateLives", 1);
            Debug.Log("Enemy!");
            Destroy(other.gameObject);
        }
    }
 
} 
