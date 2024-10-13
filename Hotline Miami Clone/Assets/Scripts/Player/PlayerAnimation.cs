using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimate : MonoBehaviour
{
    public Sprite[] legsSpr, walking, attacking;
    int legCount = 0; int counter = 0;
    CharacterMovement pm;
    float legTimer = 0.05f, timer = 0.05f;

    public SpriteRenderer legs, torso;
    SpriteContainer2D sc;

    // Start is called before the first frame update
    bool attackingB = false;
    void Start()
    {
        //Debug.Log($"����� ��������");
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteContainer2D>();
        walking = sc.getPlayerUnarmedWalk();
        attacking = sc.getPlayerPunch();
        legsSpr = sc.getPlayerLegs();
        legs = this.GetComponent<SpriteRenderer>();
        torso = this.GetComponent<SpriteRenderer>();
        //Debug.Log($"������");
    }

    // Update is called once per frame
    void Update()
    {
        animateLegs();
        {
            if(attackingB == false)
            {
                animateTorso();
            }
            else
            {
                animateAttack();
            }
        }
    }


    void animateLegs()
    {

        if (pm.moving == true) // �������� �����
        {
        
        legs.sprite = legsSpr[legCount];


        
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
         }
    }

    void animateTorso()
    {
        if (pm.moving)
        {
            torso.sprite = walking[counter];
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                if (counter < walking.Length - 1) 
                {
                    counter++;
                }
                else
                {
                    counter = 0;
                }
                timer = 0.1f; 
            }
        }
    }

    void animateAttack()
    {
        torso.sprite = attacking[counter];
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            if (counter < attacking.Length - 1) 
            {
                counter++;
            }
            else
            {
                if (attackingB)
                {
                    attackingB = false;
                }
                counter = 0;
            }
            timer = 0.05f; 
        }
    }

    public void attack()
    {
        Debug.Log("�������� �����");
        attackingB = true;
    }
    public void resetCounter()
    {
        counter = 0;
    }
    public bool getAttack()
    {
        return attackingB;
    }
    public void setNewTorso(Sprite[] walk, Sprite[] attack)
    {
        counter = 0;
        attacking = attack;
        walking = walk;
    }
}