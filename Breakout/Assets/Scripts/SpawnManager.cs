using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject powerupPrefab;

    private bool stopSpawning = false;

    void Start()
    {
        StartCoroutine(SpawnPowerupRoutine());
    }

 
    IEnumerator SpawnPowerupRoutine()
    {
        yield return new WaitForSeconds(2.5f);

        while (stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 4.6f, 0);
            Instantiate(powerupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }

}
