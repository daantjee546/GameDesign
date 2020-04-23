using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class HealthBarHandler : MonoBehaviour
{
    public static Image HealthBarImage;
    static float lives = 1;

    public static void SetHealthBarValue(float value)
    {
        try
        {
            HealthBarImage.fillAmount = value;
            if (HealthBarImage.fillAmount < 0.2f)
            {
                SetHealthBarColor(Color.red);
            }
            else if (HealthBarImage.fillAmount < 0.4f)
            {
                SetHealthBarColor(Color.yellow);
            }
            else
            {
                SetHealthBarColor(Color.green);
            }
        }
        catch (NullReferenceException)
        {

        }
        catch (MissingReferenceException)
        {

        }
    }

    public static float GetHealthBarValue()
    {
        try
        {
            return HealthBarImage.fillAmount;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    private void Start()
    {
        HealthBarImage = GetComponent<Image>();
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Scene1")
        {
            lives = lives + 1;
        }
        else if (sceneName == "BossScene")
        {
            SetHealthBarValue(lives);
            Debug.Log(lives);
        }
    }

    void Update()
    {
        lives = GetHealthBarValue();
    }
}
