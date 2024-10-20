using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.interfaces;

public class MeleeAttackStrategy : MonoBehaviour, IAttackStrategy
{
    public float attackRadius = 1f; // Радиус атаки (зона, в которой будет поражать врагов)
    public LayerMask enemyLayer;    // Слой врагов, которых можно атаковать

    private bool isAutomaticAttackEnabled = false;
    private float lastAttackTime;
    public float attackRate = 1f;   // Скорость атак

    void Awake()
    {
        enemyLayer = LayerMask.GetMask("Destroiable"); // Замените "Enemy" на имя вашего слоя
    }

    // Включение автоматической атаки
    public void EnableAutomaticAttack()
    {
        isAutomaticAttackEnabled = true;
    }

    // Отключение автоматической атаки
    public void DisableAutomaticAttack()
    {
        isAutomaticAttackEnabled = false;
    }

    // Метод атаки, использующий firePoint и текущие параметры оружия
    public void Attack(Transform firePoint, Weapon currentWeapon)
    {
        if (firePoint == null)
        {
            Debug.LogError("FirePoint is null! Cannot perform melee attack.");
            return;
        }

        if (Time.time - lastAttackTime >= 1f / attackRate)
        {
            lastAttackTime = Time.time;
            PerformMeleeAttack(firePoint, currentWeapon);
        }
    }

    // Обновление для автоматической атаки
    private void Update()
    {
        // Автоматическая атака, если включена
        if (isAutomaticAttackEnabled)
        {
            Attack(transform, null);  // Предполагается, что firePoint передается в ручном режиме извне
        }
    }

    // Выполнение атаки ближнего боя
    private void PerformMeleeAttack(Transform firePoint, Weapon currentWeapon)
    {
        // Найдем всех врагов в зоне атаки
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(firePoint.position, attackRadius, enemyLayer);
        Debug.Log("attack performed");

        foreach (Collider2D enemy in hitEnemies)
        {
            // Здесь можно вызвать метод нанесения урона врагу
            Debug.Log("Hit enemy: " + enemy.name);
            // Пример нанесения урона:
            // enemy.GetComponent<Enemy>().TakeDamage(currentWeapon.damageAmount); // Используем параметры оружия
        }
    }

    // Визуализация зоны атаки в редакторе
    private void OnDrawGizmosSelected()
    {
        // Если firePoint не установлен, использовать Transform объекта
        Transform gizmoPoint = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(gizmoPoint.position, attackRadius);
    }
}
