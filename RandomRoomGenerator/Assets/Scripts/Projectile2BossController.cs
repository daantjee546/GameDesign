using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        Debug.DrawRay(transform.position + transform.right, transform.right * attackRange, Color.green);
        Debug.DrawRay(transform.position + -transform.right, -transform.right * attackRange, Color.green);

        RaycastHit2D hitLeft = Physics2D.Raycast(transform.position + transform.right, transform.right, attackRange);
        RaycastHit2D hitRight = Physics2D.Raycast(transform.position + transform.right, -transform.right, attackRange);

        if (hitLeft.collider.tag == "Player")
        {
            // hit the player
            GameObject newAttack = Instantiate(duplicatedProjectile, transform.position, transform.rotation);
            newAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, attackForce));
            Destroy(gameObject);
        }
        if (hitRight.collider.tag == "Player")
        {
            GameObject newAttack = Instantiate(duplicatedProjectile, transform.position, transform.rotation);
            newAttack.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(0f, attackForce));
            Destroy(gameObject);
        }
        Debug.Log(hitLeft.collider.tag);
        Debug.Log(hitRight.collider.tag);
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
