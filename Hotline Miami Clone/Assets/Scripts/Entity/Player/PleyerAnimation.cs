using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    Sprite[] legsSpr;
    //walking, attacking,
    int legCount = 0;
    CharacterMovement pm;
    float legTimer = 0.05f;
    public SpriteRenderer legs;
    SpriteContainer2D sc;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"Старт Анимация");
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteContainer2D>();
        //walking = sc.getPlayerUnarmedWalk();
        legsSpr = sc.getPlayerLegs();
        legs = this.GetComponent<SpriteRenderer>();
        //Debug.Log($"Готово");
    }

    // Update is called once per frame
    void Update()
    {
        animateLegs();
        //animateTorso();
    }


    void animateLegs()
    {
        //Debug.Log($"Значение тамера1 {legTimer}");
        //Debug.Log($"Значение счетчика1 {legCount}");
        //Debug.Log($"Анимация");
        //bool v = pm.x != 0 || pm.y != 0;
        if (pm.canMove == true) // Изменено здесь
        {

            legs.sprite = legsSpr[legCount];

            //Debug.Log($"{legsSpr[legCount].name}");

            legTimer -= Time.deltaTime;

            if (legTimer <= 0)
            {
                if (legCount < legsSpr.Length - 1)
                {
                    legCount++;
                }
                else
                {
                    legCount = 0;
                }
                legTimer = 0.05f;
            }
            //Debug.Log($"Значение тамера2 {legTimer}");
        }
    }
}