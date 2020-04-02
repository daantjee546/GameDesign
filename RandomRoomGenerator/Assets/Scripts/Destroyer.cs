﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private float waitTime = 1.5f;

    private void Start()
    {
        Destroy(gameObject, waitTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "SpawnPoint")
        {
            Destroy(collision.gameObject);
        }
    }
}
