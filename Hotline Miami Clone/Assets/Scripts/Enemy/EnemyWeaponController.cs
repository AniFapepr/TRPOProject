using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponConroller : MonoBehaviour
{
    public GameObject oneHandSpawn, twoHandSpawn, bullet, blood;
    GameObject curWeapon;
    public bool gun = false;
    float timer = 0.1f, timerReset = 0.1f;

    SpriteContainer sc;
    float weaponChange = 0.5f;
    bool changingWeapon = false;
    bool oneHanded = false;

    EnemyAI eai;
    GameObject player;

    SpriteRenderer sr;

    private void Start()
    {
        eai = this.GetComponent<EnemyAI>();
        player = GameObject.FindGameObjectWithTag("Player");
        sr = this.GetComponent<SpriteRenderer>();
        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteContainer>();
    }

    void Update()
    {
        if (gun == true)
        {
            eai.hasGun = true;
        }
        else
        {
            eai.hasGun = false;
        }
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        if (eai.hasGun == false && gun == false && eai.pursuingPlayer == true && timer <= 0 && Vector3.Distance(this.transform.position, player.transform.position) <= 1.6f)
        {
            attack();
        }
        else if (eai.hasGun == true && gun == false && eai.pursuingPlayer == true && timer <= 0 && Vector3.Distance(this.transform.position, player.transform.position) <= 5.0f)
        {
            attack();
        }

        if (changingWeapon == true)
        {
            weaponChange -= Time.deltaTime;
            if (changingWeapon == false)
            {
                changingWeapon = false;
            }
        }

    }
}