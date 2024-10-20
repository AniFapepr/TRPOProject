using UnityEngine;

namespace Assets.Scripts.Player
{
    public class TorsoAnimateScript : MonoBehaviour
    {
        private Sprite[] torsoSprites; // Спрайты торса
        private SpriteRenderer spriteRenderer; // Спрайт рендерер для торса
        private float timer;  // Таймер для анимации
        private float timerValue;  // Начальное значение таймера
        private int count = 0;  // Индекс текущего спрайта

        public TorsoAnimateScript(Sprite[] torsoSprites, SpriteRenderer spriteRenderer, float timer = 0.1f)
        {
            this.torsoSprites = torsoSprites;  // Инициализируем спрайты торса
            this.spriteRenderer = spriteRenderer;  // Инициализируем спрайт рендерер
            this.timerValue = timer;  // Устанавливаем таймер
            this.timer = this.timerValue;  // Сбрасываем таймер
        }

        // Метод для анимации торса
        public void SetTorsoAnimation(bool isAnimating)
        {
            if (isAnimating)
            {
                AnimateTorso();
            }
            else
            {
                StopTorsoAnimation();
            }
        }

        // Анимация торса
        private void AnimateTorso()
        {
            spriteRenderer.sprite = torsoSprites[count];  // Устанавливаем текущий спрайт
            timer -= Time.deltaTime;  // Уменьшаем таймер

            if (timer <= 0)
            {
                count = (count + 1) % torsoSprites.Length;  // Переходим к следующему спрайту
                timer = timerValue;  // Сбрасываем таймер
            }
        }

        // Остановка анимации торса
        private void StopTorsoAnimation()
        {
            count = 0;  // Сбрасываем индекс спрайтов
            spriteRenderer.sprite = torsoSprites[count];  // Устанавливаем первый спрайт
        }

        // Метод для смены спрайтов торса при смене оружия
        public void UpdateTorsoSprites(Sprite[] newTorsoSprites)
        {
            this.torsoSprites = newTorsoSprites;  // Обновляем спрайты для торса
            count = 0;  // Сбрасываем текущий индекс
        }
    }
}
