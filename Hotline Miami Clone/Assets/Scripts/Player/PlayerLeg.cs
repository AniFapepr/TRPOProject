using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public class Leg : MonoBehaviour
    {
        private ControlSystem controlSystem;
        private Vector3 rot;

        void Start()
        {
            controlSystem = new ControlSystem();
            rot = Vector3.zero;
        }

        void Update()
        {
            rot = Vector3.zero; // ���������� ��������� ����

            if (controlSystem.IsUpKeyPressed()) // �����
            {
                if (controlSystem.IsRightKeyPressed()) // ������
                    rot = new Vector3(0, 0, 45);
                else if (controlSystem.IsLeftKeyPressed()) // �����
                    rot = new Vector3(0, 0, 135);
                else
                    rot = new Vector3(0, 0, 90);
            }
            else if (controlSystem.IsDownKeyPressed()) // ����
            {
                if (controlSystem.IsRightKeyPressed()) // ������
                    rot = new Vector3(0, 0, 315);
                else if (controlSystem.IsLeftKeyPressed()) // �����
                    rot = new Vector3(0, 0, 225);
                else
                    rot = new Vector3(0, 0, 270);
            }
            else if (controlSystem.IsLeftKeyPressed()) // �����
            {
                rot = new Vector3(0, 0, 180);
            }
            else if (controlSystem.IsRightKeyPressed()) // ������
            {
                rot = new Vector3(0, 0, 0);
            }

            transform.eulerAngles = rot; // ��������� ����
        }
    }
}
