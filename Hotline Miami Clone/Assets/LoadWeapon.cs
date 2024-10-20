using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadWeapon : MonoBehaviour
{
    private SpritesContainer2D spriteContainer;
    public string pathToWeapon = "Sprites/Entity/Player/Player1/Weapon";

    void Start()
    {
        spriteContainer = GetComponent<SpritesContainer2D>(); // �������� ��������� SpriteContainer2D
        Sprite[] WeaponSprites = LoadWeaponSprites(); // ��������� �������

        if (WeaponSprites != null)
        {
            spriteContainer.setSprites(WeaponSprites); // �������� ������� � ����� setSprites
            spriteContainer.SetSpritesName("Weapon");
        }
    }

    // ������ ���� ����� public, ����� ��� ����� ���� �������� �� ������ �������
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
