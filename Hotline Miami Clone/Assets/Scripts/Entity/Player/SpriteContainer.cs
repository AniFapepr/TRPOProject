using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer2D : MonoBehaviour
{
    public Sprite[] pLegs;

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


}
