using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile2BossController : MonoBehaviour
{
    public float duplicationTime;
    public GameObject duplicatedProjectile;

    public float attackRange;
    public float attackForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            Debug.DrawLine(transform.position + transform.right, transform.right * attackRange, Color.green);
            Debug.DrawLine(transform.position + -transform.right, -transform.right * attackRange, Color.green);

            RaycastHit2D hitRight = Physics2D.Raycast(transform.position + transform.right, transform.right, attackRange);
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + -transform.right, -transform.right, attackRange);

            if (hitRight.collider.tag == "Player")
            {
                Instantiate(duplicatedProjectile, transform.position, transform.rotation);
                Destroy(gameObject);
            }
            if (hitLeft.collider.tag == "Player")
            {
                Instantiate(duplicatedProjectile, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
        catch (NullReferenceException)
        {
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.1f);
        }
    }
}
