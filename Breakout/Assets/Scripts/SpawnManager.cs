using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject enemy;

    [Header("Variables")]
    public bool stopSpawning;

    private AudioSource audioSource;

    private static SpawnManager instance;
    public static SpawnManager Instance { get { return instance; } }

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();  
        stopSpawning = true;
    }

    private void Update()
    {
        if (transform.position.y <= -6.0f)
        {
            Destroy(enemy);
        }
    }

    public IEnumerator SpawnEnemyRoutine()
    {
        while (stopSpawning == false)
        {
            yield return new WaitForSeconds(Random.Range(5, 10));
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 4.6f, 0);
            GameObject newEnemy = Instantiate(enemy, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
            
    }

    public void PlayBonusSound()
    {
        audioSource.Play();
    }

    public void BoolSystemFalse()
    {
        stopSpawning = false;
    }

    public void BoolSystemTrue()
    {
        stopSpawning = true;
    }

    public void StartSpawnCoroutines()
    {
        StartCoroutine(SpawnEnemyRoutine());
    }

    public void StopSpawnCoroutines()
    {
        StopCoroutine(SpawnEnemyRoutine());
    }

}
