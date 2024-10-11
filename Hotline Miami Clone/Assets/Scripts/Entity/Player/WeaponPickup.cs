using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public string weaponName;
    public float fireRate;
    WeaponAttack wa;
    public bool gun;
    void Start()
    {
        wa = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player" && Input.GetMouseButtonDown(1))
        {
            Debug.Log("Player picked up; +" + name);
            if(wa.getCur() != null)
            {
                wa.dropWeapon();
            }
        }
        wa.setWeapon(this.gameObject, weaponName, fireRate, gun);
        this.gameObject.SetActive(false);
    }
}
