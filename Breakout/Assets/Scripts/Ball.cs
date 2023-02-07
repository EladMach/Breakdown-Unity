using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Variables")]
    public float _speed = 5.0f;
    private bool isMoving = false;


    private Vector2 startingPosition;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private SpawnManager spawnManager;
   
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
    }

    void Start()
    {
        spawnManager = FindObjectOfType<SpawnManager>();
        audioSource = GetComponent<AudioSource>();  
        startingPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isMoving == false)
        {
            isMoving = true;
            spawnManager.stopSpawning = false;
            spawnManager.StartCoroutine(spawnManager.SpawnPowerupRoutine());
            rb.AddForce(Vector2.up * _speed);
        }

        if (transform.position.y <= -8.5f)
        {
            isMoving = false;
            spawnManager.stopSpawning = true;
            spawnManager.StopCoroutine(spawnManager.SpawnPowerupRoutine());
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

        if (other.gameObject.CompareTag("WallLeft"))
        {
            audioSource.Play();
            rb.velocity = new Vector2(7f, Random.Range(4f, -4f) * _speed * Time.deltaTime);
        }
        if (other.gameObject.CompareTag("WallRight"))
        {
            audioSource.Play();
            rb.velocity = new Vector2(-7f, Random.Range(4f, -4f) * _speed * Time.deltaTime);
        }
        if (other.gameObject.CompareTag("WallUp"))
        {
            audioSource.Play();
            rb.velocity = new Vector2(Random.Range(-7f, -7), -4f) * _speed * Time.deltaTime;
        }

    }

}
