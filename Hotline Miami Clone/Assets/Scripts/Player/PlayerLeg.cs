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
            rot = Vector3.zero; // Сбрасываем начальный угол

            if (controlSystem.IsUpKeyPressed()) // Вверх
            {
                if (controlSystem.IsRightKeyPressed()) // Вправо
                    rot = new Vector3(0, 0, 45);
                else if (controlSystem.IsLeftKeyPressed()) // Влево
                    rot = new Vector3(0, 0, 135);
                else
                    rot = new Vector3(0, 0, 90);
            }
            else if (controlSystem.IsDownKeyPressed()) // Вниз
            {
                if (controlSystem.IsRightKeyPressed()) // Вправо
                    rot = new Vector3(0, 0, 315);
                else if (controlSystem.IsLeftKeyPressed()) // Влево
                    rot = new Vector3(0, 0, 225);
                else
                    rot = new Vector3(0, 0, 270);
            }
            else if (controlSystem.IsLeftKeyPressed()) // Влево
            {
                rot = new Vector3(0, 0, 180);
            }
            else if (controlSystem.IsRightKeyPressed()) // Вправо
            {
                rot = new Vector3(0, 0, 0);
            }

            transform.eulerAngles = rot; // Применяем угол
        }
    }
}
