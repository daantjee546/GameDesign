using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Image youDied;
    public GameObject projectile;
    public GameObject specialProjectile;
    public float moveSpeed;

    public float offset;
    public float cooldown = 1.0f;
    public float specialCooldown = 1.0f;

    private Rigidbody2D rb;
    private float nextFire;
    private float nextSpecialFire;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Scene1")
        {
            HealthBarHandler.SetHealthBarValue(1);
        }
        else if (sceneName == "BossScene")
        {
            HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue());
        }
    }

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

        else if(Input.GetKeyDown("space") && Time.time > nextSpecialFire)
        {
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + -90f);
            Instantiate(specialProjectile, transform.position, rotation);
            nextSpecialFire = Time.time + specialCooldown;
        }

        if (HealthBarHandler.GetHealthBarValue() <= 0)
        {
            youDied.enabled = true;
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.05f);
        }
        if(collision.gameObject.tag == "heart")
        {
            HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() + 0.2f);
        }
    }

}