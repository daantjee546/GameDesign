﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{
    public GameObject[] topRooms;
    public GameObject[] bottomRooms;
    public GameObject[] leftRooms;
    public GameObject[] rightRooms;

    public GameObject closedRoom;
    public List<GameObject> rooms;
    public float waitTime;
    public GameObject boss;

    private bool spawnedBoss;

    private void Update()
    {
        if (waitTime <= 0 && !spawnedBoss)
        {
            Instantiate(boss, rooms[rooms.Count-1].transform.position, Quaternion.identity);
            spawnedBoss = true;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
