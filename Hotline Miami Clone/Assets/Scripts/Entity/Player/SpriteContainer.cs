using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpritesContainer2D : MonoBehaviour
{
    public Sprite[] sprites;
    public string spritesName = null;

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
    public string getSpritesName(){
        return spritesName;
    }

     public void setSprites(Sprite[] sprites)
    {
        this.sprites = sprites;
    }
    public void SetSpritesName(string name){
        this.spritesName = name;
    }


}


public class SpriteContainer2D : MonoBehaviour
{
    public Sprite sprite;
    public string spriteName = null;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log($"����� SpriteContainer2D");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Sprite getSprite()
    {
        //Debug.Log($"�������� ������");
        return sprite;
    }
    public string getSpriteName(){
        return spriteName;
    }


}
