using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject doubleBallPowerup;
    public GameObject ballPrefab;
    public bool _stopSpawning = false;


    //private Player _player;
    //private Ball ball;
    void Start()
    {
        //ball = FindObjectOfType<Ball>();
        //_player = FindObjectOfType<Player>();
        //StartCoroutine(SpawnPowerupRoutine());
    }

    private void Update()
    {
        //PowerUpBall();
    }

    //public IEnumerator SpawnPowerupRoutine()
    //{
    //    yield return new WaitForSeconds(5.0f);

    //    while (_stopSpawning == false)
    //    {
    //        Vector3 posToSpawn = new Vector3(Random.Range(-8.0f, 8.0f), 4.5f, 0);           
    //        Instantiate(doubleBallPowerup, posToSpawn, Quaternion.identity);
    //        yield return new WaitForSeconds(Random.Range(3, 10));
    //    }

    //}

    //public void PowerUpBall()
    //{
    //    if (_player._isPowerup == true)
    //    {
    //        Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
    //        _player._isPowerup = false;
    //    }
    //}

    
}
