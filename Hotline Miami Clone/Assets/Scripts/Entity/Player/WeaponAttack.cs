using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttack : MonoBehaviour
{
    GameObject bullet, curWeapon;
    bool gun = false;
    float timer = 0.1f, timerReset = 0.1f;
    PlayerAnimate pa;
    SpriteContainer2D sc;
    float weaponChange = 0.5f;
    bool changingWeapon = false;
    void Start()
    {
        pa = this.GetComponent<PlayerAnimate>();
        sc = GameObject.FindGameObjectWithTag("GameController").GetComponent<SpriteContainer2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Debug.Log("Стрелять");
            attack();
        }
        if(Input.GetMouseButtonDown(0))
        {
            pa.resetCounter();
        }
        if(Input.GetMouseButtonUp(0))
        {
            pa.resetCounter();
        }

        if (Input.GetMouseButtonDown(1) && changingWeapon == false)
        {
            dropWeapon();
        }

        if(changingWeapon == true)
        {
            weaponChange -= Time.deltaTime;
            if(weaponChange <= 0)
            {
                changingWeapon = false;
            }
        }
    }





    public void setWeapon(GameObject cur, string weaponName, float fireRate, bool gun)
    {
        changingWeapon=true;
        curWeapon = cur;
        Debug.Log($"Оружие");
        pa.setNewTorso(sc.GetWeaponWalk(weaponName), sc.GetWeapon(weaponName)); // тут баг <--------------------
        Debug.Log($"Оружие");
        this.gun = gun;
        timerReset = fireRate;
        timer = timerReset;
       
    }

    public void attack()
    {
        pa.attack ();
    }

    public GameObject getCur()
    {
        return curWeapon;
    }

    public void dropWeapon()
    {
        curWeapon.transform.position = this.transform.position;
        curWeapon.SetActive(true);
        setWeapon(null, "", 0.5f, false);
    }
}
