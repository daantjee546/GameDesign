using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public Image youWin;

    // Start is called before the first frame update
    void Start()
    {
        HealthBarHandler.SetHealthBarValue(1);
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthBarBoss.GetHealthBarValue() <= 0)
        {
            youWin.enabled = true;
            Destroy(gameObject);
            SceneManager.LoadScene("Scene1");
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HealthBarBoss.SetHealthBarValue(HealthBarHandler.GetHealthBarValue() - 0.1f);
        }

        if (HealthBarBoss.GetHealthBarValue() <= 0)
        {
            Destroy(gameObject);
        }
    }*/
}
