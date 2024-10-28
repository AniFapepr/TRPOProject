using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeapon : MonoBehaviour
{
    private Sprite[] weaponSprites;
    public string pathToWeapon = "Sprites/Entity/Player/Player1/Weapon"; // Путь к спрайтам оружия

    void Start()
    {
        LoadWeaponSprites();
    }

    public Sprite[] LoadWeaponSprites()
    {
        weaponSprites = Resources.LoadAll<Sprite>(pathToWeapon);
        Debug.Log("Загружено " + weaponSprites.Length + " спрайтов из " + pathToWeapon);
        if (weaponSprites.Length == 0)
        {
            Debug.LogError("No weapon sprites found in Resources/Sprites.");
        }
        return weaponSprites; // Возвращаем массив спрайтов
    }

    public Sprite[] GetWeaponSprites()
    {
        return weaponSprites;
    }
}
