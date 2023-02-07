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

    public IEnumerator SpawnPowerupRoutine()
    {
        while (stopSpawning == false)
        {
            yield return new WaitForSeconds(2.0f);
            int randomPowerUp = Random.Range(0, 2);
            Vector3 posToSpawn = new Vector3(Random.Range(-8.5f, 8.5f), 4.6f, 0);
            Instantiate(powerups[randomPowerUp], posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(5, 10));
        }
 
    }
 

}
