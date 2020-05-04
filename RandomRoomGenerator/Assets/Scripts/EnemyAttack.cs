using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAttack : MonoBehaviour
{
    public GameObject projectile;
    public Transform target;
    public float attackRange;
    public float attackDelay;
    public float attackForce;

    private float lastAttackTime;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        try
        {
            
            float distanceToPlayer = Vector3.Distance(transform.position, target.position);
            if (distanceToPlayer < attackRange)
            {
                Vector3 targerDir = target.position - transform.position;
                float angle = Mathf.Atan2(targerDir.y, targerDir.x) * Mathf.Rad2Deg - 90f;
                Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

                if (Time.time > lastAttackTime + attackDelay)
                {
                    RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);

                    if (true)
                    {
                        // hit the player
                        GameObject newAttack = Instantiate(projectile, transform.position, transform.rotation);
                        newAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, attackForce));
                        lastAttackTime = Time.time;
                    }
                }

            }
        }
        catch (NullReferenceException)
        {

        }
    }
}
