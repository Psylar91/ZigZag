using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right,
    }

    public float MoveSpeed { get; private set; } = 2.0f;
    private const float SpeedWeight = 0.005f;
    private Direction direction = Direction.Left;

    void Update()
    {
        ChangeDirection();
        Move();
        Accelarate();
    }

    public void Move()
    {
        if (direction == Direction.Right)
        {
            transform.position += new Vector3(MoveSpeed * Time.deltaTime, 0f, 0f);
        }
        else
        {
            transform.position += new Vector3(0f, 0f, MoveSpeed * Time.deltaTime);
        }
    }

    public void ChangeDirection()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(direction == Direction.Right)
            {
                direction = Direction.Left;
            }
            else
            {
                direction = Direction.Right;
            }
        }
    }

    public void Accelarate()
    {
        MoveSpeed += SpeedWeight * Time.deltaTime;
    }
}
