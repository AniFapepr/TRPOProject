using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    //public GameObject() enemies;
    public GameObject NextPlaceToGo;
    static bool canTravel = true;
    float timer = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timerCountdown();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && areAllEnemiesDead() == true && canTravel == true)
        {
            collision.transform.position = NextPlaceToGo.transform.position;
            canTravel = false;
        }
    }
    public bool areAllEnemiesDead()
    {
        /*for(int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].tag != "Dead")
            {
                return false;
            }
        }*/
        return true;
    }
    void timerCountdown()
    {
        if(canTravel == false)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                canTravel = true;
                timer = 1.0f;
            }
        }
    }
}
