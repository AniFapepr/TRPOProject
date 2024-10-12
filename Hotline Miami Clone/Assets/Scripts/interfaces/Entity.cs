using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.interfaces{
    public abstract class Entity : MonoBehaviour
    {
        public float MovementSpeed = 5f; // Установите скорость движения по умолчанию
        

        // Методы для движения и поворота
        public abstract void Move();
        public abstract void Rotate();
    }
}