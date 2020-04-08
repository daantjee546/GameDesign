using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followmouse : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 10.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
