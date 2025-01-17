using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    [Header("Variables")]
    public int rows;
    public int columns;
    public float spacing;
    
    [Header("GameObjects")]
    public GameObject brickPrefab;

    private List<GameObject> bricks = new List<GameObject>();

    public static BrickManager instance;
    public static BrickManager Instance { get { return instance; } }

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
        BuildLevel();
    }

    public void BuildLevel()
    {
        foreach (GameObject brick in bricks)
        {
            Destroy(brick);
        }
        bricks.Clear();

        for (int x = 0; x < columns; x++)
        { 
            for (int y = 0; y < rows; y++)
            {
                Vector2 spawnPos = (Vector2)transform.position + new Vector2(
                    x * (brickPrefab.transform.localScale.x + spacing),
                    -y * (brickPrefab.transform.localScale.y + spacing));

                GameObject brick = Instantiate(brickPrefab, spawnPos, Quaternion.identity);
                bricks.Add(brick);
                    
            }
        }
    }

}
