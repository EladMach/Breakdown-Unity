using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _movementSpeed = 10f;
    public bool _isPowerup = false;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovment();
    }

    void CalculateMovment()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector2(horizontalInput, 0);

        transform.Translate(direction * _movementSpeed * Time.deltaTime);

        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -4.7f, 0));
    }

    
} 
