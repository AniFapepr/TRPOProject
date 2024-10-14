using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnwmyAttacked : MonoBehaviour
{
    public Sprite knockedDown, stabbed, bulletWound,backUp;
    public GameObject bloodPool, bloodSpurt;
    SpriteRenderer sr;
    bool EnemyKnockedDown = false;
    float knockDownTimer = 3.0f;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyKnockedDown == true)
        {
            knockDown();
        }
    }
    public void knockDownEnemy()
    {
        EnemyKnockedDown=true;
    }
    void knockDown()
    {
        this.GetComponent<EnemyWeaponController>().dropWeapon();
        this.GetComponent<EnemyWeaponController>().enabled = false;
        knockDownTimer -= Time.deltaTime;
        sr.sprite = knockedDown;
        this.GetComponent<CircleCollider2D>().enabled = false;
        sr.sortingOrder = 2;
        this.GetComponent<EnemyAI>().enabled = false;
        this.GetComponent<EnemyAnimate>().disableLegs();
        this.GetComponent<EnemyAnimate>().enabled = false;
        if(knockDownTimer <= 0)
        {
            EnemyKnockedDown = false;
            sr.sprite = backUp;
            this.GetComponent<CircleCollider2D>().enabled = true;
            this.GetComponent<EnemyAI>().enabled = true;
            this.GetComponent<EnemyWeaponController>().enabled = true;
            this.GetComponent<EnemyAnimate>().enabled = true;
            this.GetComponent<EnemyAnimate>().disableLegs();
            sr.sortingOrder = 5;
            knockDownTimer = 3.0f;
        }
    }
    public void killBullet()
    {
        this.GetComponent<EnemyWeaponController>().dropWeapon();
        this.GetComponent<EnemyWeaponController>().enabled = false;
        sr.sprite = bulletWound;
        Instantiate(bloodPool, this.transform.position, this.transform.rotation);
        sr.sortingOrder = 2;
        this.GetComponent <EnemyAI>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<EnemyAnimate>().disableLegs();
        this.GetComponent<EnemyAnimate>().enabled = false;
        this.gameObject.tag = "Dead";
    }
    public void killMelee()
    {
        this.GetComponent<EnemyWeaponController>().dropWeapon();
        this.GetComponent<EnemyWeaponController>().enabled = false;
        sr.sprite = stabbed;
        Instantiate(bloodPool, this.transform.position, this.transform.rotation);
        Instantiate(bloodSpurt, this.transform.position, player.transform.rotation);
        sr.sortingOrder = 2;
        this.GetComponent<EnemyAI>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
        this.GetComponent<EnemyAnimate>().disableLegs();
        this.GetComponent<EnemyAnimate>().enabled = false;
        this.gameObject.tag = "Dead";
    }
}
