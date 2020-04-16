using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private enum bossStates
    {
        idle,
        attack1,
        attack2,
        attack3
    }

    private bossStates currentState;

    public Transform target;
    public float attackRange;

    private bossStates lastAttack;
    private float lastAttackTime;
    private float lastAttack1Time;
    private float lastAttack2Time;
    private float lastAttack3Time;

    public float idleDelay;
    public float attackDelay;
    public float attack1Delay;
    public float attack2Delay;
    public float attack3Delay;

    public GameObject projectile;
    public GameObject projectile2;

    public float attackForce;
    public float attack2Force;

    // Start is called before the first frame update
    void Start()
    {
        currentState = bossStates.idle;
        lastAttack = bossStates.idle;
        lastAttackTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        // check if in range
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            Vector3 targerDir = target.position - transform.position;
            float angle = Mathf.Atan2(targerDir.y, targerDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            switch (currentState)
            {
                case bossStates.idle:
                    idle();
                    break;
                case bossStates.attack1:
                    attack1();
                    break;
                case bossStates.attack2:
                    attack2();
                    break;
                case bossStates.attack3:
                    attack3();
                    break;
                default:
                    break;
            }
        }
    }
    private void idle()
    {
        if (Time.time > lastAttackTime + idleDelay)
        {
            bossStates newAttack = (bossStates)Random.Range(1, 4);
            if (lastAttack != newAttack)
            {
                currentState = newAttack;
                lastAttackTime = Time.time;
            }
        }
    }

    void attack1()
    {
        if (Time.time > lastAttack1Time + attack1Delay)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);

            if (hit.transform == target)
            {
                GameObject newAttack = Instantiate(projectile, transform.position, transform.rotation);
                newAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, attackForce));
            }
            lastAttack1Time = Time.time;
        }
        checkTime(1);
    }
    void attack2()
    {
        if (Time.time > lastAttack2Time + attack2Delay)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);

            if (hit.transform == target)
            {
                GameObject newAttack = Instantiate(projectile2, transform.position, transform.rotation);
                newAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, attack2Force));
            }
            lastAttack2Time = Time.time;
        }
        checkTime(2);
    }
    void attack3()
    {
        if (Time.time > lastAttack3Time + attack3Delay)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);

            if (hit.transform == target)
            {
                GameObject newAttack = Instantiate(projectile, transform.position, transform.rotation);
                newAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, attackForce));
            }
            lastAttack3Time = Time.time;
        }
        checkTime(3);
    }

    void checkTime(int attack)
    {
        if (Time.time > lastAttackTime + attackDelay)
        {
            currentState = bossStates.idle;
            lastAttack = (bossStates)attack;
            lastAttackTime = Time.time;
        }
    }
}