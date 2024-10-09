using UnityEngine;

namespace Assets.Scripts.Player
{
    public class SpriteAnimator : MonoBehaviour
    {
        private Sprite[] sprites; // Массив спрайтов для анимации
        private SpriteRenderer spriteRenderer;
        private float animationTimer;
        private float animationSpeed = 0.05f; // Скорость анимации
        private int currentFrame = 0;

        public SpriteAnimator(Sprite[] animationSprites, SpriteRenderer renderer, float speed = 0.05f)
        {
            sprites = animationSprites;
            spriteRenderer = renderer;
            animationSpeed = speed;
        }

        public void SetAnimating(bool isAnimating)
        {
            if (isAnimating)
            {
                Animate();
            }
            else
            {
                StopAnimation();
            }
        }

        private void Animate()
        {
            animationTimer -= Time.deltaTime;

            if (animationTimer <= 0)
            {
                spriteRenderer.sprite = sprites[currentFrame];
                currentFrame = (currentFrame + 1) % sprites.Length;
                animationTimer = animationSpeed;
            }
        }

        private void StopAnimation()
        {
            currentFrame = 0;
            spriteRenderer.sprite = sprites[currentFrame];
        }
    }
}
