using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] waypoints;
    public int _currentWaypointIndex = 0;
    public float _speed = 2f;

    void Start()
    {
        StartCoroutine(RandomWaypointIndex());
    }

    void Update()
    {       

        Transform wp = waypoints[_currentWaypointIndex];

        if (Vector3.Distance(transform.position, wp.position) < 1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
        }

    }

    private IEnumerator RandomWaypointIndex()
    {
        yield return new WaitForSeconds(5f);
        _currentWaypointIndex = Random.Range(0, waypoints.Length);
        yield return new WaitForSeconds(5f);
    }


}
