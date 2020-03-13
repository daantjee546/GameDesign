using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;

    public Transform Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HealthBarHandlerEnemy.SetHealthBarValue(1);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        FollowTarget();
    }

    private void FollowTarget()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 0.01f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        HealthBarHandlerEnemy.SetHealthBarValue(HealthBarHandlerEnemy.GetHealthBarValue() - 0.1f);
        if (HealthBarHandlerEnemy.GetHealthBarValue() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
