using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2f;
    float nextSpawn = 0;
    int amountOfEnemies = 0;
    int count = 0;


    // Start is called before the first frame update
    void Start()
    {
        amountOfEnemies = Random.Range(2, 4);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn && amountOfEnemies != count)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(enemy, transform.position, Quaternion.identity);
            count++;
        }
    }
}
