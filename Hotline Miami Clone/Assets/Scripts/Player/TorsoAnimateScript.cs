using UnityEngine;

namespace Assets.Scripts.Player
{
    public class TorsoAnimateScript : MonoBehaviour
    {
        private Sprite[] torsoSprites; // ������� �����
        private SpriteRenderer spriteRenderer; // ������ �������� ��� �����
        private float timer;  // ������ ��� ��������
        private float timerValue;  // ��������� �������� �������
        private int count = 0;  // ������ �������� �������

        public TorsoAnimateScript(Sprite[] torsoSprites, SpriteRenderer spriteRenderer, float timer = 0.1f)
        {
            this.torsoSprites = torsoSprites;  // �������������� ������� �����
            this.spriteRenderer = spriteRenderer;  // �������������� ������ ��������
            this.timerValue = timer;  // ������������� ������
            this.timer = this.timerValue;  // ���������� ������
        }

        // ����� ��� �������� �����
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

        // �������� �����
        private void AnimateTorso()
        {
            spriteRenderer.sprite = torsoSprites[count];  // ������������� ������� ������
            timer -= Time.deltaTime;  // ��������� ������

            if (timer <= 0)
            {
                count = (count + 1) % torsoSprites.Length;  // ��������� � ���������� �������
                timer = timerValue;  // ���������� ������
            }
        }

        // ��������� �������� �����
        private void StopTorsoAnimation()
        {
            count = 0;  // ���������� ������ ��������
            spriteRenderer.sprite = torsoSprites[count];  // ������������� ������ ������
        }

        // ����� ��� ����� �������� ����� ��� ����� ������
        public void UpdateTorsoSprites(Sprite[] newTorsoSprites)
        {
            this.torsoSprites = newTorsoSprites;  // ��������� ������� ��� �����
            count = 0;  // ���������� ������� ������
        }
    }
}
