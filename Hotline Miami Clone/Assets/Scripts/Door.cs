using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            if(Vector3.Distance (player.transform.position, this.transform.position) < 1.0)
            {
                //EnemyAttacked ea = collision.gameObject.GetComponent<EnemyAttacked>();
                //ea.knockDownEnemy();
            }
        }
            
    }
}
