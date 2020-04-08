using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectilecontroller : MonoBehaviour
{
    private float speed = 10f;
    private bool isMoving;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
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
    }
}
