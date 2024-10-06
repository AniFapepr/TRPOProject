using UnityEngine;

namespace Assets.Scripts.Player
{
    public class CharacterMovementAnimate : MonoBehaviour
    {
        private Sprite[] legsSpr; // Спрайты ног
        private SpriteRenderer legs;
        private float legTimer = 0.05f;
        private int legCount = 0;

        public CharacterMovementAnimate(Sprite[] legsSprites, SpriteRenderer spriteRenderer)
        {
            legsSpr = legsSprites;
            legs = spriteRenderer;
        }

        public void SetMoving(bool isMoving)
        {
            if (isMoving)
            {
                AnimateLegs();
            }
            else
            {
                StopLegAnimation();
            }
        }

        void AnimateLegs()
        {
            legs.sprite = legsSpr[legCount];
            legTimer -= Time.deltaTime;

            if (legTimer <= 0)
            {
                legCount = (legCount + 1) % legsSpr.Length;
                legTimer = 0.05f;
            }
        }

        void StopLegAnimation()
        {
            legCount = 0;
            legs.sprite = legsSpr[legCount];
        }
    }
}
