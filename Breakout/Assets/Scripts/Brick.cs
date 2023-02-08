using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int health;
    private int maxHealth = 2;

    void Start()
    {
        health = maxHealth;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ball"))
        {
            health--;
        }
        if (health == 0)
        {
            Destroy(this.gameObject);
        }
    }

}
