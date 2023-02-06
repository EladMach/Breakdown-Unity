using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    
    public float _speed = 5.0f;

    private GameManager _gameManager;
    
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        Respawn();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -8.5f)
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
            _gameManager.score++;
            Destroy(other.gameObject);
        }
    }
}
