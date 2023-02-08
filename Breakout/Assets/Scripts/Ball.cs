using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Variables")]
    public float _speed = 60f;
    private bool isMoving = false;

    private Vector2 startingPosition;

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Transform paddel;
    private Vector3 offset = new Vector3(0, 0.5f, 0);

    public static Ball instance;
    public static Ball Instance { get { return instance; } }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        paddel = transform.parent;
    }

    void Start()
    {
        startingPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false)
        {
            isMoving = true;
            rb.isKinematic = false;
            Leave();
            rb.AddForce(transform.up * _speed * Time.deltaTime);
            rb.velocity = new Vector2(Random.Range(-6, 6), 4f);
            SpawnManager.Instance.SendMessageUpwards("BoolSystemFalse");
            SpawnManager.Instance.SendMessageUpwards("StartSpawnPowerup");
            
        }

        if (transform.position.y <= -8.5f)
        {
            transform.position = paddel.position + offset;
            rb.velocity = Vector2.zero;
            isMoving = false;
            rb.isKinematic = true;
            Rejoin();
            SpawnManager.Instance.SendMessageUpwards("BoolSystemTrue");
            SpawnManager.Instance.SendMessageUpwards("StopSpawnPowerup");
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
            Debug.Log("Ball hit");
        }

        if (other.gameObject.CompareTag("Wall"))
        {
            audioSource.Play();
            
        }

    }
    public void Leave()
    {
        transform.SetParent(null);
    }

    //Come back to the parent!
    public void Rejoin()
    {
        transform.SetParent(paddel);
    }


}
