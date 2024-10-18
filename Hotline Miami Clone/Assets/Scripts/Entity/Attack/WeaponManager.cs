using UnityEngine;

namespace Assets.Scripts.Player
{
    public class WeaponManager : MonoBehaviour
    {
        private GameObject currentWeapon; // Текущее оружие
        public GameObject defaultWeapon;  // Оружие по умолчанию
        public float pickupRadius = 2f; // Радиус для поиска оружия
        public LayerMask weaponLayer;   // Слой, на котором находятся объекты с оружием

        void Start()
        {
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

        // Получение текущего оружия
        public GameObject GetCurrentWeapon()
        {
            if(currentWeapon == null)
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
                Debug.Log("Оружие на полу обнаружено: ");

                // Меняем текущее оружие игрока
                currentWeapon = groundWeapon;
            }
            else
            {
                Debug.Log("Оружие на полу не найдено.");
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


        // Визуализация радиуса подбора оружия в редакторе
        private void OnDrawGizmosSelected()
        {
            if (currentWeapon != null)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireSphere(transform.position, pickupRadius);
            }
        }
    }
}
