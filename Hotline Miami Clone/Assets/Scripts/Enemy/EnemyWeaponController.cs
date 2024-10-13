using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class EnemyWeaponController : MonoBehaviour
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

    bool attacking = false;
    SpriteRenderer sr;
    EnemyAnimate ea;
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
            ea.setAttacking();
        }
        else if (eai.hasGun == true && gun == false && eai.pursuingPlayer == true && timer <= 0 && Vector3.Distance(this.transform.position, player.transform.position) <= 5.0f)
        {
            attack();
            ea.setAttacking();
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
    public bool getAttacking()
    {
        return attacking;
    }
    public void setWeapon(GameObject cur, string name, float fireRate, bool gun, bool oneHanded)
    {
        changingWeapon = true;
        curWeapon = cur;
        sr.sprite = sc.getEnemySprite(name);
        this.gun = gun;
        timerReset = fireRate;
        timer = timerReset;
        this.oneHanded = oneHanded;
        ea.setTorsoSpr(name);
    }
    public void attack()
    {
        if (gun == true)
        {
            Bullet bl = bullet.GetComponent<Bullet>();
            Vector3 dir;
            dir.x = Vector2.right.x;
            dir.y = Vector2.right.y;
            dir.z = 0;
            bl.setVals(dir, "Enemy");
            if (oneHanded == true)
            {
                Instantiate(bullet, oneHandSpawn.transform.position, this.transform.rotation);
            }
            else
            {
                Instantiate(bullet, oneHandSpawn.transform.position, this.transform.rotation);
            }
            timer = timerReset;
        }
        else
        {
            int layerMask = 1 << 8;
            layerMask = ~layerMask;
            RaycastHit2D ray = Physics2D.Raycast(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(transform.right.x, transform.right.y), 1.5f, layerMask);
            Debug.DrawRay(new Vector2(this.transform.position.x, this.transform.position.y), new Vector2(transform.right.x, transform.right.y), Color.green);
            Debug.Log("попытка атаки");
            if (curWeapon == null && ray.collider.gameObject.tag == "Player")
            {
                Debug.Log("Удар игрока");
                //EnemyAttacked ea = ray.collider.gameObject.GetComponent<EnemyAttacked>();
                //ea.knockDownEnemy ();
            }
            else if (ray.collider != null)
            {
                if (ray.collider.gameObject.tag == "Player")
                {
                    Debug.Log("попытка атки враг");
                    //EnemyAttacked ea = ray.collider.gameObject.GetComponent<EnemyAttacked>();
                    //ea.killMelee ();
                }
            }
            Instantiate(blood, player.transform.position, player.transform.rotation);
            timer = timerReset;
        }
    }
   public GameObject getCur()
    {
        return curWeapon;
    }
    public void dropWeapon()
    {
        if(curWeapon == null)
        {

        }
        else
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            curWeapon.AddComponent<ThrowWeapon>();
            Vector3 dir;
            dir.x = mousePos.x - this.transform.position.x;
            dir.y = mousePos.y - this.transform.position.y;
            dir.z = 0;
            curWeapon.GetComponent<Rigidbody2D>().isKinematic = false;
            curWeapon.GetComponent<ThrowWeapon> ().setDirection(dir);
            curWeapon.transform.position = oneHandSpawn.transform.position;
            curWeapon.transform.eulerAngles = this.transform.eulerAngles;
            curWeapon.SetActive(true);
            setWeapon(null,"", 0.5f, false,false);
            //pa.resetSprites();
        }
    }
}
    //не все сделано

