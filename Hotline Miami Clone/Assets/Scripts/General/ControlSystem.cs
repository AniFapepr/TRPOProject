using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.General
{
    internal public class ControlSystem
    {
        private static KeyCode rightKey = KeyCode.D;
        private static KeyCode leftKey = KeyCode.A;
        private static KeyCode upperKey = KeyCode.W;
        private static KeyCode downKey = KeyCode.S;
        private static KeyCode cameraViewKey = KeyCode.Shift;
        private static KeyCode dropWeaponKey = KeyCode.Mouse1;
        private static KeyCode fireKey = KeyCode.Mouse0;

        public static KeyCode RightKey{get => rightKey; set => right = value;}
        public static KeyCode LeftKey{get => leftKey; set => leftKey = value;}
        public static KeyCode UppertKey{get => upperKey; set => upperKey = value;}
        public static KeyCode DownKey{get => downKey; set => downKey = value;}

        public static KeyCode CameraViewKeyKey{get => cameraViewKey; set => cameraViewKey = value;}
        public static KeyCode DropWeaponKey{get => dropWeaponKey; set => dropWeaponKey = value;}
        public static KeyCode FireKey{get => fireKey; set => fireKey = value;}
    }
    
}

