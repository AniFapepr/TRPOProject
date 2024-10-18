using UnityEngine;

namespace Assets.Scripts.Player
{
    public class AnimateScript : MonoBehaviour
    {
        private Sprite[] sprites; // Спрайты ног
        private SpriteRenderer spriteRenderer;
        private float timer;
        private float timerValue;
        private int count = 0;

        public AnimateScript(Sprite[] legsSprites, SpriteRenderer spriteRenderer, float timer = 0.01f)
        {
            this.sprites = legsSprites;
            this.spriteRenderer = spriteRenderer;
            this.timerValue = timer;
            this.timer = this.timerValue;
        }

        public void SetMoving(bool isMoving)
        {
            if (isMoving)
            {
                Animate();
            }
            else
            {
                StopAnimation();
            }
        }

        void Animate()
        {
            spriteRenderer.sprite = sprites[count];
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                count = (count + 1) % sprites.Length;
                timer = timerValue;
            }
        }

        void StopAnimation()
        {
            count = 0;
            spriteRenderer.sprite = sprites[count];
        }
    }
}