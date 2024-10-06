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
<<<<<<< Updated upstream
=======
        private CharacterMovementAnimate playerAnimate;
>>>>>>> Stashed changes
        public float acceleration = 5f;
        public float deceleration = 5f;
        private Rigidbody2D rb;
        private Sprite[] legSprites;
        private SpriteRenderer legsRenderer; // Новый рендерер для ног

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();

            if (rb == null)
            {
                Debug.LogError("Rigidbody2D component is missing from Player.");
            }

            // Загрузка спрайтов для анимации
            legSprites = Resources.LoadAll<Sprite>("Sprites/Entity/Player/Player1/Legs");

            if (legSprites.Length == 0)
            {
                Debug.LogError("No foot sprites found in Resources/Sprites.");
            }

            // Получаем SpriteRenderer для ног
            GameObject legsObject = new GameObject("Legs"); // Создаем новый объект для ног
            legsObject.transform.SetParent(transform); // Устанавливаем его родителем игрока
            legsRenderer = legsObject.AddComponent<SpriteRenderer>(); // Добавляем компонент SpriteRenderer

            if (legsRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing from Legs.");
            }

            // Инициализация стратегии движения и анимации
            ControlSystem controlSystem = new ControlSystem();
            playerAnimate = new CharacterMovementAnimate(legSprites, legsRenderer); // Правильная инициализация
            movementStrategy = new PlayerMovementStrategy(controlSystem, playerAnimate);
        }

        public override void Move()
        {
            movementStrategy?.Move(this, acceleration, deceleration);
        }

        public override void Rotate()
        {
            movementStrategy?.Rotate(this);
        }

        void Update()
        {
            Move();
            Rotate();
            playerAnimate.SetMoving(movementStrategy.IsMoving()); // Передаем состояние движения для анимации
        }
    }
}
