using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Ball>().Respawn();
    }
}
