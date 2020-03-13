using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private EnemyMovement parent;

    private void Start()
    {
        parent = GetComponentInParent<EnemyMovement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            parent.Target = collision.transform;
        }
        parent.Target = collision.transform;
    }
}
