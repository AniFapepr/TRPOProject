using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class KeyBindings
{
    public KeyCode moveUp = KeyCode.W;
    public KeyCode moveDown = KeyCode.S;
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode interact = KeyCode.E; // Пример для взаимодействия
}

public class InputManager : MonoBehaviour
{
    public KeyBindings keyBindings;

    public float GetHorizontalInput()
    {
        if (Input.GetKey(keyBindings.moveLeft)) return -1;
        if (Input.GetKey(keyBindings.moveRight)) return 1;
        return 0;
    }

    public float GetVerticalInput()
    {
        if (Input.GetKey(keyBindings.moveDown)) return -1;
        if (Input.GetKey(keyBindings.moveUp)) return 1;
        return 0;
    }
}
