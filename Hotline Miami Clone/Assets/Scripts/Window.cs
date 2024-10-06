using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    public Sprite brokenWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
        {
            breakWindow();
        }
    }
    public void breakWindow()
    {
        BoxCollider2D bc2d = this.GetComponent<BoxCollider2D>();
        bc2d.enabled = false;
        this.GetComponent<SpriteRenderer>().sprite = brokenWindow;
        this.GetComponent<SpriteRenderer>().sortingOrder = 1;
    }
}
