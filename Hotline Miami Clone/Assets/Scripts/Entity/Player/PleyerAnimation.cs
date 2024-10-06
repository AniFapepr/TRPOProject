using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;

public class PlayerAnimate : MonoBehaviour
{
    Sprite[] legsSpr;
    //walking, attacking,
    int legCount = 0;
    PlayerMovementStrategy pm;
    float legTimer = 0.05f;
    public SpriteRenderer legs;
    SpriteContainer2D sc;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"����� ��������");
        //pm = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().GetComponent<PlayerMovementStrategy>();
        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteContainer2D>();
        //walking = sc.getPlayerUnarmedWalk();
        legsSpr = sc.getPlayerLegs();
        legs = this.GetComponent<SpriteRenderer>();
        //Debug.Log($"������");
    }

    // Update is called once per frame
    void Update()
    {
        animateLegs();
        //animateTorso();
    }


    void animateLegs()
    {
        //Debug.Log($"�������� ������1 {legTimer}");
        //Debug.Log($"�������� ��������1 {legCount}");
        //Debug.Log($"��������");
        //bool v = pm.x != 0 || pm.y != 0;
        // Ghbdgfsdfgsf
        if (pm.IsMoving() == true) // �������� �����
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
            //Debug.Log($"�������� ������2 {legTimer}");
        }
    }
}