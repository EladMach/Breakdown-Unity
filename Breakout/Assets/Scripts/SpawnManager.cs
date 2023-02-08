using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject[] powerups;

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

    public IEnumerator SpawnPowerupRoutine()
    {
        while (stopSpawning == false)
        {
            yield return new WaitForSeconds(10f);
            int randomPowerUp = Random.Range(0, 2);
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 4.6f, 0);
            Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
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

    public void StartSpawnPowerup()
    {
        StartCoroutine(SpawnPowerupRoutine());
    }

    public void StopSpawnPowerup()
    {
        StopCoroutine(SpawnPowerupRoutine());
    }

}
