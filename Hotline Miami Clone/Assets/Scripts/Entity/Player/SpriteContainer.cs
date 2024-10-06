using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer2D : MonoBehaviour
{
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"����� SpriteContainer2D");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite[] getSprites()
    {
        //Debug.Log($"�������� ������");
        return sprites;
    }


}
