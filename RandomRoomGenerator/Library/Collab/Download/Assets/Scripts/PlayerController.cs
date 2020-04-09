using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public Image youDied;

    public GameObject projectile;
    public float offset;
    public float cooldown = 1.0f;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        HealthBarHandler.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * moveSpeed;
        float moveVertical = Input.GetAxis("Vertical") * moveSpeed;
        rb.velocity = new Vector2(moveHorizontal, moveVertical);

        if (Input.GetMouseButton(0) && Time.time > nextFire)
        {

            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + -90f);
            Instantiate(projectile, transform.position, rotation);
            nextFire = Time.time + cooldown;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.1f);
        }
        
        if (HealthBarHandler.GetHealthBarValue() <= 0)
        {
            youDied.enabled = true;
            Destroy(gameObject);
        }
    }
}