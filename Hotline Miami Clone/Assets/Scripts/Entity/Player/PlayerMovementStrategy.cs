using System;
using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.interfaces;

namespace Assets.Scripts.Player
{
    public class PlayerMovementStrategy : IMovementStrategy
    {
        private ControlSystem controlSystem;
        private Vector2 currentVelocity = Vector2.zero; // Текущая скорость
        private float x = 0f;
        private float y = 0f;

        public PlayerMovementStrategy(ControlSystem controlSystem = null)
        {
            this.controlSystem = controlSystem ?? new ControlSystem();
        }

        public void Move(Entity entity, float acceleration, float deceleration)
        {
            // Используем ControlSystem для получения осей ввода
            x = controlSystem.IsRightKeyPressed() ? 1f : controlSystem.IsLeftKeyPressed() ? -1f : 0f;
            y = controlSystem.IsUpKeyPressed() ? 1f : controlSystem.IsDownKeyPressed() ? -1f : 0f;

            // Создаем вектор желаемого направления движения
            Vector2 targetVelocity = new Vector2(x, y).normalized * entity.MovementSpeed;

            // Если игрок хочет двигаться, то применяем ускорение
            if (targetVelocity.magnitude > 0.1f)
            {
                currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, Time.deltaTime * acceleration);
            }
            // Если игрок не вводит направления, то замедляем персонажа
            else
            {
                currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, Time.deltaTime * deceleration);
            }

            // Применяем текущую скорость к Rigidbody2D
            Rigidbody2D rb = entity.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = currentVelocity;
            }
            else
            {
                Debug.LogError("Rigidbody2D not found on entity.");
            }
        }

        public void Rotate(Entity entity)
        {
            // Позиция мыши в мировых координатах
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - entity.transform.position;

            // Рассчитываем угол для поворота персонажа
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Поворачиваем объект
            entity.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
