using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player{

public class ControlSystem
    {
        private static KeyCode rightKey = KeyCode.D;
        private static KeyCode leftKey = KeyCode.A;
        private static KeyCode upKey = KeyCode.W;
        private static KeyCode downKey = KeyCode.S;
        private static KeyCode attackKey = KeyCode.Mouse0;
        private static KeyCode throwKey = KeyCode.Mouse1;


        public bool IsRightKeyPressed() => Input.GetKey(rightKey);
        public bool IsLeftKeyPressed() => Input.GetKey(leftKey);
        public bool IsUpKeyPressed() => Input.GetKey(upKey);
        public bool IsDownKeyPressed() => Input.GetKey(downKey);

        public bool IsAttackPressed() => Input.GetKey(attackKey);
        public bool IsThrowPressed() => Input.GetKey(throwKey);
      
        public void SetRightKey(KeyCode key) => rightKey = key;
        public void SetLeftKey(KeyCode key) => leftKey = key;
        public void SetUpKey(KeyCode key) => upKey = key;
        public void SetDownKey(KeyCode key) => downKey = key;

        public void SetAttackKey(KeyCode key) => attackKey = key;
        public void SetThrowKey(KeyCode key) => throwKey = key;

    }
}

