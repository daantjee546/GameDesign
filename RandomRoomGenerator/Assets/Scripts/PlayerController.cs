using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    public Image youDied;

    public GameObject projectile;
    public GameObject specialProjectile;

    public float offset;
    public float cooldown = 1.0f;
    public float specialCooldown = 1.0f;

    static float livesValue = 1;

    private float nextFire;
    private float nextSpecialFire;

    // Start is called before the first frame update
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

        else if(Input.GetKeyDown("space") && Time.time > nextSpecialFire)
        {
            //Debug.Log("SPACE PRESSED...");
            Vector2 target = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
            Vector2 myPos = new Vector2(transform.position.x, transform.position.y);
            Vector2 direction = target - myPos;
            direction.Normalize();
            Quaternion rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + -90f);
            
            Instantiate(specialProjectile, transform.position, rotation);
            
            nextSpecialFire = Time.time + specialCooldown;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            //Debug.Log("HIT PLAYER....");
            HealthBarHandler.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.05f);
        }

        if (HealthBarHandler.GetHealthBarValue() <= 0)
        {
            youDied.enabled = true;
            gameObject.SetActive(false);
            //Destroy(gameObject);
        }
    }

}