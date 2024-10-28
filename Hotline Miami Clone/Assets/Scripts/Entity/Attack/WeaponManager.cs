using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private GameObject currentWeapon; // Текущее оружие
    public GameObject defaultWeapon;  // Оружие по умолчанию
    public float pickupRadius = 2f; // Радиус для поиска оружия
    public LayerMask weaponLayer;   // Слой, на котором находятся объекты с оружием

    // Референс на игрока
    public Player player; // Убедитесь, что этот объект установлен в инспекторе

    void Start()
    {
        if (defaultWeapon == null)
        {
            Debug.LogError("Weapon default is null from WPM. Устанавливаю оружие по умолчанию.");
            SetDefaultWeapon(Resources.Load<GameObject>("Path/To/Your/DefaultWeaponPrefab")); // Укажите правильный путь
        }
        else
        {
            Debug.Log("Default weapon: " + defaultWeapon.name);
        }

        currentWeapon = defaultWeapon;

        if (currentWeapon == null)
        {
            Debug.LogError("Weapon is null from WPM in start");
        }
        else
        {
            Debug.Log("Current weapon: " + currentWeapon.name);
        }
    }

    public GameObject GetCurrentWeapon()
    {
        if (currentWeapon == null)
        {
            Debug.LogError("Weapon is null from WPM");
        }
        return currentWeapon;
    }

    public void SetDefaultWeapon(GameObject weapon)
    {
        defaultWeapon = weapon;
    }

    public void ChangeWeapon(Player player)
    {
        GameObject groundWeapon = FindWeaponOnGround(player);

        if (groundWeapon != null)
        {
            Debug.Log("Оружие на полу обнаружено: " + groundWeapon.name);
            currentWeapon = groundWeapon;

            string weaponName = currentWeapon.GetComponent<Weapon>().WeaponName;
            if (weaponName == "M4A1" || weaponName == "Pistol" || weaponName == "Uzi")
            {
                ChangeTorsoSprite(weaponName);
            }
        }
        else
        {
            Debug.Log("Оружие на полу не найдено.");
        }
    }

    private GameObject FindWeaponOnGround(Player player)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, pickupRadius, weaponLayer);

        foreach (Collider2D collider in colliders)
        {
            if (collider.GetComponent<Weapon>() != null)
            {
                return collider.gameObject;
            }
        }
        return null;
    }

    private void ChangeTorsoSprite(string weaponName)
    {
        Debug.Log("Смена запущена для " + weaponName);
        if (currentWeapon != null)
        {
            LoadWeapon loadWeapon = currentWeapon.GetComponent<LoadWeapon>();
            if (loadWeapon != null)
            {
                Sprite[] weaponSprites = loadWeapon.LoadWeaponSprites();
                if (weaponSprites != null && weaponSprites.Length > 0)
                {
                    GameObject torsoObject = GameObject.FindWithTag("Torso");
                    if (torsoObject != null)
                    {
                        SpriteRenderer torsoRenderer = torsoObject.GetComponent<SpriteRenderer>();
                        if (torsoRenderer != null)
                        {
                            switch (weaponName)
                            {
                                case "M4A1":
                                    torsoRenderer.sprite = weaponSprites[0]; // Первый спрайт для M4A1
                                    break;
                                case "Pistol":
                                    if (weaponSprites.Length > 1)
                                        torsoRenderer.sprite = weaponSprites[1]; // Второй спрайт для Pistol
                                    break;
                                case "Uzi":
                                    if (weaponSprites.Length > 2)
                                        torsoRenderer.sprite = weaponSprites[2]; // Третий спрайт для Uzi
                                    break;
                            }
                            Debug.Log($"Спрайт Torso изменен на спрайт оружия {weaponName}.");
                        }
                    }
                    else
                    {
                        Debug.LogError("Torso объект не найден.");
                    }
                }
                else
                {
                    Debug.LogError("Нет спрайтов оружия.");
                }
            }
            else
            {
                Debug.LogError("LoadWeapon компонент не найден на текущем оружии.");
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (currentWeapon != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, pickupRadius);
        }
    }
}




