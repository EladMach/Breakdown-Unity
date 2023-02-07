using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private void Update()
    {
        if (transform.position.y < -6f)
        {
            Destroy(this.gameObject);
        }
    }
}
