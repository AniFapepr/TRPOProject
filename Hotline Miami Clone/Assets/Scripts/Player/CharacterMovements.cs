using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    // Перемещение перса
    Rigidbody2D rb;
    public float speed;
    float x;
    float y;

    public bool canMove = false;

    // Поворот перса
    Vector3 mousePosition;
    Vector3 direct;

    Camera cam;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void Update()
    {

        InputManager();
        //if (Input.GetKey(KeyCode.W))
        //{
        //Debug.Log("W");
        //transform.Translate (Vector3.up * 5 * Time.deltaTime,Space.World); 

        //}
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            MovementManager();
        }
        RotationCharacter();
    }

    private void InputManager()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        if (x != 0 || y != 0)
        {
            canMove = true;
        }
        else
        {
            canMove = false;
        }
    }

    private void MovementManager()
    {
        rb.velocity = new Vector2(x * speed, y * speed);
    }

    private void RotationCharacter()
    {
        mousePosition = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - cam.transform.position.z));
        rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}