using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float _movementSpeed = 10f;
    public bool _isPowerup = false;

    private Ball _ball;
    private SpawnManager spawnManager;
    // Start is called before the first frame update
    void Start()
    {
        _ball = FindObjectOfType<Ball>();
        spawnManager = FindObjectOfType<SpawnManager>(); 
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

    //public void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("DoubleBall"))
    //    {
    //        Debug.Log("Another One!");
    //        _isPowerup = true;
    //        Destroy(other.gameObject);
    //    }
    //}
} 
