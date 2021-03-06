﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectilecontroller : MonoBehaviour
{
    private float speed = 10f;
    private bool isMoving;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 0.75f);
    }

    void Update()
    {
        if (!isMoving)
        {
            Vector3 sp = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 direction = (Input.mousePosition - sp).normalized;
            rb.velocity = direction * speed;
            isMoving = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Boss")
        {
            Destroy(this.gameObject);
            HealthBarBoss.SetHealthBarValue(HealthBarBoss.GetHealthBarValue() - 0.03f);
        }
    }
}
