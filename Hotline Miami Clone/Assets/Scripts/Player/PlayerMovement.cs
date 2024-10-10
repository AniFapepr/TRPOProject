using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Перемещение перса
    public bool moving = true;
    public float speed = 10.0f;
    private void Update()
    {
        if(moving == true)
        {
            movement();
        }
        movementCheck();
    }
    public void setMoving(bool val)
    {
        moving = val;
    }
    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate (Vector3.up * speed * Time.deltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            moving = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            moving = true;
        }
        if(Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true)
        {
            moving = false;
        }
    }
    void movementCheck()
    {
        if (Input.GetKey(KeyCode.D) != true && Input.GetKey(KeyCode.A) != true && Input.GetKey(KeyCode.W) != true && Input.GetKey(KeyCode.S) != true)
        {
            moving = false;
        }
        else
        {
            moving = true;
        }
    }
}