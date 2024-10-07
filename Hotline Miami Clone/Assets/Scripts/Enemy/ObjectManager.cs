using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] weapons;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        weapons = GameObject.FindGameObjectsWithTag("Weapon");
    }
    public GameObject[] getWeapons()
    {
        return weapons;
    }

}
