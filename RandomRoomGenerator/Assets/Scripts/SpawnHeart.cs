using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHeart : MonoBehaviour
{
    public GameObject Heart;
    public float spawnRate = 5f;
    float nextSpawn = 5;
    int amountOfHearts = 0;
    int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        amountOfHearts = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn && amountOfHearts != count)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(Heart, transform.position, Quaternion.identity);
            count++;
        }
    }
}
