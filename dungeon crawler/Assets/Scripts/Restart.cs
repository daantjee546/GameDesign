using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    [System.Obsolete]
    public void RestartGame()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
