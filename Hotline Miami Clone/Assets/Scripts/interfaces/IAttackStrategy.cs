using UnityEngine;

namespace Assets.Scripts.interfaces
{
    public interface IAttackStrategy
    {
        void Attack(Transform firePoint, Weapon currentWeapon);
        void EnableAutomaticAttack();  // Метод для включения автоматической атаки
        void DisableAutomaticAttack(); // Метод для отключения автоматической атаки
    }
}
