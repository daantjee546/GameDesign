using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    public Image youWin;

    void Start()
    {
        HealthBarHandler.SetHealthBarValue(1);
    }

    void Update()
    {
        if (HealthBarBoss.GetHealthBarValue() <= 0)
        {
            youWin.enabled = true;
            Destroy(gameObject);
            SceneManager.LoadScene("Scene1");
        }
    }
}
