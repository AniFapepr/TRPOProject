using UnityEngine;

namespace Assets.Scripts.interfaces{
public interface IMovementStrategy
{
    // Метод для перемещения персонажа
    void Move(Entity entity, float acceleration, float deceleration);

    // Метод для вращения персонажа
    void Rotate(Entity entity);

   
}
}
