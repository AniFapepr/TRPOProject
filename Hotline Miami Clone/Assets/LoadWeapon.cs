using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeapon : MonoBehaviour
{
    private SpritesContainer2D spriteContainer;
    public string pathToWeapon = "Sprites/Entity/Player/Player1/Weapon";

    void Start()
    {
        spriteContainer = GetComponent<SpritesContainer2D>(); // Получаем компонент SpriteContainer2D
        Sprite[] WeaponSprites = LoadWeaponSprites(); // Загружаем спрайты

        if (WeaponSprites != null)
        {
            spriteContainer.setSprites(WeaponSprites); // Передаем спрайты в метод setSprites
            spriteContainer.SetSpritesName("Weapon");
        }
    }

    // Теперь этот метод public, чтобы его можно было вызывать из других классов
    public Sprite[] LoadWeaponSprites()
    {
        Sprite[] WeaponSprites = Resources.LoadAll<Sprite>(pathToWeapon);

        if (WeaponSprites.Length == 0)
        {
            Debug.LogError("No weapon sprites found in Resources/Sprites.");
            return null;
        }
        return WeaponSprites;
    }
}
