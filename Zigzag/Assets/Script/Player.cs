using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float SpeedWeight = 0.1f;
    public bool moveX = false;

    void Update()
    {
        if (moveX)
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
        else
            transform.position += new Vector3(0f, 0f, moveSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse0))
            moveX = !moveX;

        moveSpeed += SpeedWeight * Time.deltaTime;
    }
}
