using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Ball : MonoBehaviour
{
   
    public float _speed = 5.0f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Respawn();
        }
        if (transform.position.y < -8.5f)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
         transform.position = Vector3.zero;
         GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle.normalized * _speed;
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Brick"))
        {
            gameObject.SendMessageUpwards("AddScore", 1);
            Destroy(other.gameObject);
            
        }

    }

    


}
