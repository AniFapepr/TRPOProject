using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.interfaces;

namespace Assets.Scripts.Player
{
    public class Player : Entity
    {
        private IMovementStrategy movementStrategy;
        private PlayerAnimate playerAnimate;
        public float acceleration = 5f;
        public float deceleration = 5f;
        private Rigidbody2D rb;

        void Start()
        {
            // Инициализация Rigidbody2D
            rb = GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component is missing from Player.");
            }

            // Инициализация стратегии движения
            ControlSystem controlSystem = new ControlSystem();
            movementStrategy = new PlayerMovementStrategy(controlSystem);

            // Проверим, что стратегия была успешно создана
            if (movementStrategy == null)
            {
                Debug.LogError("Movement strategy is not initialized.");
            }
        }

        public override void Move()
        {
            // Проверка на наличие стратегии
            if (movementStrategy != null)
            {
                movementStrategy.Move(this, acceleration, deceleration);
            }
            else
            {
                Debug.LogError("Movement strategy is null in Move()");
            }
        }

        public override void Rotate()
        {
            // Проверка на наличие стратегии
            if (movementStrategy != null)
            {
                movementStrategy.Rotate(this);
            }
            else
            {
                Debug.LogError("Movement strategy is null in Rotate()");
            }
        }

        void Update()
        {
            // Вызываем движение и вращение
            Move();
            Rotate();
        }
    }
}
