using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer2D : MonoBehaviour
{
    public Sprite[] pLegs, pM4A1Walk, pPunch, pM4A1Attack, pUnarmedWalk, pPistolWalk, pPistolAttack;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"Старт SpriteContainer2D");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite[] getPlayerLegs()
    {
        //Debug.Log($"Передача ссылки");
        return pLegs;
    }
    public Sprite[] getPlayerUnarmedWalk()
    {
        //Debug.Log($"Передача ссылки");
        return pUnarmedWalk;
    }

    public Sprite[] getPlayerPunch()
    {
        return pPunch;
    }

    public Sprite[] GetWeapon(string weapon)
    {   
        switch (weapon) // Corrected spelling from 'swith' to 'switch'
        {
            case "M4A1":
                return pM4A1Attack;
            case "Pistol":
                return pPistolAttack; 
            default:
                return getPlayerPunch (); 
        }
    }

    public Sprite[] GetWeaponWalk(string weapon)
    {
        switch (weapon) 
        {
            case "M4A1":
                return pM4A1Walk;
            case "Pistol":
                return pPistolWalk; 
            default:
                return getPlayerUnarmedWalk(); 
        }
    }
}