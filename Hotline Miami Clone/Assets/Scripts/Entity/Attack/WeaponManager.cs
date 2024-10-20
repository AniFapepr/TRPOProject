using UnityEngine;

namespace Assets.Scripts.Player
{
    public class WeaponManager : MonoBehaviour
    {
        private Sprite[] sprites; // Спрайты ног
        private SpriteRenderer spriteRenderer;

        public WeaponManager(Sprite[] WeaponSprites, SpriteRenderer spriteRenderer)
        {
            this.sprites = WeaponSprites;
            this.spriteRenderer = spriteRenderer;
        }

        private GameObject currentWeapon; // Текущее оружие
        public GameObject defaultWeapon;  // Оружие по умолчанию
        public float pickupRadius = 2f; // Радиус для поиска оружия
        public LayerMask weaponLayer;   // Слой, на котором находятся объекты с оружием
        public LoadWeapon loadWeapon;  // Скрипт загрузки оружия
        public GameObject torso; // Объект торса
        public SpriteRenderer torsoSpriteRenderer; // Рендерер для спрайта торса

        void Start()
        {
            // Попытка получить компонент LoadWeapon
            loadWeapon = GetComponent<LoadWeapon>();
            if (loadWeapon == null)
            {
                Debug.LogError("LoadWeapon component is missing from the object.");
            }
            else
            {
                // Получаем SpriteRenderer для торса
                if (torso != null)
                {
                    torsoSpriteRenderer = torso.GetComponent<SpriteRenderer>();
                }
                if (defaultWeapon == null)
                    Debug.LogError("Weapon default is null from WPM");
                else
                    Debug.Log("Default weapon: " + defaultWeapon.name); // Выводим имя оружия по умолчанию
                currentWeapon = defaultWeapon;
                if (currentWeapon == null)
                    Debug.LogError("Weapon is null from WPM in start");
                else
                    Debug.Log("Current weapon: " + currentWeapon.name); // Выводим имя текущего оружия
            }
        }

        // Получение текущего оружия
        public GameObject GetCurrentWeapon()
        {
            if (currentWeapon == null)
                Debug.LogError("Weapon is null from WPM");
            return currentWeapon;
        }

        // Установка оружия по умолчанию
        public void SetDefaultWeapon(GameObject weapon)
        {
            defaultWeapon = weapon;
        }

        // Метод смены оружия
        public void ChangeWeapon(Player player)
        {
            // Логика смены оружия. Например, если оружие лежит на полу:
            GameObject groundWeapon = FindWeaponOnGround(player);
            if (groundWeapon != null)
            {
                Debug.Log("Оружие на полу обнаружено: " + groundWeapon.name);
                currentWeapon = groundWeapon; // Меняем текущее оружие игрока
                UpdateTorsoSprite(); // Обновляем спрайт торса
            }
            else
            {
                Debug.Log("Оружие на полу не найдено.");
            }
        }

        // Метод обновления спрайта торса
        private void UpdateTorsoSprite()
        {
            if (loadWeapon != null)
            {
                Sprite[] WeaponSprites = loadWeapon.LoadWeaponSprites(); // Загружаем спрайты оружия
                if (WeaponSprites != null && WeaponSprites.Length > 0 && torsoSpriteRenderer != null)
                {
                    // Проверяем имя текущего оружия перед сменой спрайта
                    if (currentWeapon.name == "M4A1")
                    {
                        torsoSpriteRenderer.sprite = WeaponSprites[0]; // Задаем первый спрайт оружия на торс
                        Debug.Log("Спрайт торса обновлен для M4A1.");
                    }
                }
            }
            else
            {
                Debug.LogError("LoadWeapon script is missing.");
            }
        }

        // Метод нахождения оружия на полу рядом с игроком
        private GameObject FindWeaponOnGround(Player player)
        {
            // Используем Physics2D.OverlapCircle для поиска объектов в радиусе на слое оружия
            Collider2D[] colliders = Physics2D.OverlapCircleAll(player.transform.position, pickupRadius, weaponLayer);
            foreach (Collider2D collider in colliders)
            {
                // Проверяем, есть ли у объекта компонент Weapon
                if (collider.GetComponent<Weapon>() != null)
                {
                    return collider.gameObject; // Возвращаем объект, которому принадлежит этот коллайдер
                }
            }
            return null; // Если оружие не найдено
        }
    }
}
