using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class HealthBarHandler : MonoBehaviour
{
    private static Image HealthBarImage;
    static float lives = 0;

    /// <summary>
    /// Sets the health bar value
    /// </summary>
    /// <param name="value">should be between 0 to 1</param>
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

        
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }

    /// <summary>
    /// Sets the health bar color
    /// </summary>
    /// <param name="healthColor">Color </param>
    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    /// <summary>
    /// Initialize the variable
    /// </summary>
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
            HealthBarHandler.SetHealthBarValue(lives);
            Debug.Log(lives);
        }
        
    }

    void Update()
    {
        
        lives = GetHealthBarValue();
    }
}
