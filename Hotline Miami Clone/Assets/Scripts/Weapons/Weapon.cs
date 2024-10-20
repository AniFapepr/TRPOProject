using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Weapon : MonoBehaviour
{
    [Header("Характеристики")]
    public string WeaponName = "";
    public float attackRate = 0f;
    public int numOfAttacks = 0;
    public bool isGun = false;
    public bool isFullAuto = false;
    public float bulletForce = 0;

    [Header("Префабы")]
    public GameObject bulletPrefabObject = null;
    public GameObject playerTorsoObject = null;
    

    private void Awake()
    {
        
    }
}
