using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLegs : MonoBehaviour
{
    private SpritesContainer2D spriteContainer;
    public string pathToLegs = "Sprites/Entity/Player/Player1/Legs";

    void Start()
    {
        spriteContainer = GetComponent<SpritesContainer2D>(); // Получаем компонент SpriteContainer2D
        Sprite[] legSprites = LoadLegSprites(); // Загружаем спрайты

        if (legSprites != null)
        {
            spriteContainer.setSprites(legSprites); // Передаем спрайты в метод setSprites
            spriteContainer.SetSpritesName("Legs");
        }
    }

    private Sprite[] LoadLegSprites()
    {
        Sprite[] legSprites = Resources.LoadAll<Sprite>(pathToLegs);

        if (legSprites.Length == 0)
        {
            Debug.LogError("No foot sprites found in Resources/Sprites.");
            return null;
        }
        return legSprites;
    }
}