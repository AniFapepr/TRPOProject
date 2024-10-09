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
        private SpriteAnimator legsAnimator; // Изменено на SpriteAnimator
        public float acceleration = 5f;
        public float deceleration = 5f;
        private Rigidbody2D rb;
        private Sprite[] legSprites;

        void Start()
        {
            // Добавление Rigidbody2D, если он отсутствует
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.gravityScale = 0; // Установка гравитации в 0

            // Проверка на наличие Rigidbody2D
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

            // Создание нового SpriteRenderer для ног
            GameObject legsObject = new GameObject("Legs");
            legsObject.transform.parent = transform; // Привязка к объекту игрока
            SpriteRenderer legsRenderer = legsObject.AddComponent<SpriteRenderer>(); // Добавление нового компонента SpriteRenderer

            // Установка начального спрайта (можно выбрать первый спрайт)
            legsRenderer.sprite = legSprites.Length > 0 ? legSprites[0] : null;

            if (legsRenderer == null)
            {
                Debug.LogError("SpriteRenderer component is missing from Legs.");
            }

            // Добавление CircleCollider2D
            CircleCollider2D circleCollider = gameObject.AddComponent<CircleCollider2D>();
            circleCollider.isTrigger = true; // Установите это значение в true, если хотите, чтобы коллайдер не взаимодействовал с физикой

            // Инициализация стратегии движения и анимации
            ControlSystem controlSystem = new ControlSystem();
            legsAnimator = new SpriteAnimator(legSprites, legsRenderer); // Используем новый класс SpriteAnimator
            movementStrategy = new PlayerMovementStrategy(controlSystem, legsAnimator);
        }

        public override void Move()
        {
            movementStrategy?.Move(this, acceleration, deceleration);
        }

        public override void Rotate()
        {
            movementStrategy?.Rotate(this);
        }

        public override void Attack()
        {
            // Реализация атаки (если требуется)
        }

        void Update()
        {
            Move();
            Rotate();
            legsAnimator.SetAnimating(movementStrategy.IsMoving()); // Передача состояния движения для анимации
        }
    }
}
