using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform target;
    public float attackRange;
    private float lastAttackTime;
    public float attackDelay;
    public GameObject projectile;
    public float attackForce;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // check if in range
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            Vector3 targerDir = target.position - transform.position;
            float angle = Mathf.Atan2(targerDir.y, targerDir.x) * Mathf.Rad2Deg - 90f;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 90 * Time.deltaTime);

            // check if it's time to attack
            if (Time.time > lastAttackTime + attackDelay)
            {
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, attackRange);

                if (true)
                {
                    //Debug.Log("HIT PLAYER....");
                    // hit the player
                    GameObject newAttack = Instantiate(projectile, transform.position, transform.rotation);
                    newAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, attackForce));
                    lastAttackTime = Time.time;
                }
            }

        }
    }
}
