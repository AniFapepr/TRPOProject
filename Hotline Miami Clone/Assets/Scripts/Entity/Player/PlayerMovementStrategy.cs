using System;
using UnityEngine;
using Assets.Scripts.Player;
using Assets.Scripts.interfaces;

namespace Assets.Scripts.Player
{
    public class PlayerMovementStrategy : IMovementStrategy
    {
        private ControlSystem controlSystem;
        private Vector2 currentVelocity = Vector2.zero;
        private float x = 0f;
        private float y = 0f;
<<<<<<< Updated upstream
=======
        bool isMoving = false;
        private CharacterMovementAnimate legAnimator;
>>>>>>> Stashed changes

        public PlayerMovementStrategy(ControlSystem controlSystem = null, CharacterMovementAnimate legAnimator = null)
        {
            this.controlSystem = controlSystem ?? new ControlSystem();
            this.legAnimator = legAnimator; // Логика анимации ног
        }

        public void Move(Entity entity, float acceleration, float deceleration)
        {
            x = controlSystem.IsRightKeyPressed() ? 1f : controlSystem.IsLeftKeyPressed() ? -1f : 0f;
            y = controlSystem.IsUpKeyPressed() ? 1f : controlSystem.IsDownKeyPressed() ? -1f : 0f;

            Vector2 targetVelocity = new Vector2(x, y).normalized * entity.MovementSpeed;

            if (targetVelocity.magnitude > 0.1f)
            {
                currentVelocity = Vector2.Lerp(currentVelocity, targetVelocity, Time.deltaTime * acceleration);
<<<<<<< Updated upstream
=======
                isMoving = true;
>>>>>>> Stashed changes
            }
            else
            {
                currentVelocity = Vector2.Lerp(currentVelocity, Vector2.zero, Time.deltaTime * deceleration);
<<<<<<< Updated upstream
=======
                isMoving = false;
>>>>>>> Stashed changes
            }

            Rigidbody2D rb = entity.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = currentVelocity;

                if (rb.velocity.magnitude < 0.1f)
                {
                    isMoving = false;
                }
            }
            else
            {
                Debug.LogError("Rigidbody2D not found on entity.");
            }

            // Обновляем анимацию через legAnimator, только если есть движение
            legAnimator?.SetMoving(isMoving);
        }

        public void Rotate(Entity entity)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 direction = mousePosition - entity.transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            entity.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
<<<<<<< Updated upstream
=======

        public bool IsMoving()
        {
            return isMoving;
        }
>>>>>>> Stashed changes
    }
}
