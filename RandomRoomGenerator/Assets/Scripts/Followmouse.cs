using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Followmouse : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 10.0f;

    void Update()
    {
        mousePosition = Input.mousePosition;
        transform.position = Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
