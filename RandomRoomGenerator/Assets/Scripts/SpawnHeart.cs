using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnHeart : MonoBehaviour
{
    public GameObject Heart;
    public float spawnRate = 5f;
    float lastSpawn = 20f;

    float nextSpawn = 5;
    public float lastNextSpawn = 10;
    int amountOfHearts = 0;
    int count = 0;

    void Start()
    {
        amountOfHearts = Random.Range(1, 3);
        nextSpawn = Time.time + spawnRate;
        lastSpawn = Time.time + lastNextSpawn;
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "BossScene")
        {
            if (Time.time > nextSpawn && amountOfHearts != count)
            {
                nextSpawn = Time.time + spawnRate;
                Instantiate(Heart, transform.position, Quaternion.identity);
                count++;
            }
            if (Time.time > lastSpawn)
            {
                lastSpawn = Time.time + lastNextSpawn;
                Instantiate(Heart, transform.position, Quaternion.identity);
            }
        }

        
    }
}
