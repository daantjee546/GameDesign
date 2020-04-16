using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class musicPlayer : MonoBehaviour
{
    private static musicPlayer instance = null;
    public static musicPlayer Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
