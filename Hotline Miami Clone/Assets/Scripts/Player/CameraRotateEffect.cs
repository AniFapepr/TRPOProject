using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateEffect : MonoBehaviour
{
    CharacterMovement pm;
    float mod = 0.05f;
    float zVal = 0.0f;
    float maxTilt = 3.0f;

    void Start()
    {
        pm = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>();
    }

    void Update()
    {
        if (pm.moving) // Поверка на движение персонажа
        {
            Vector3 rot = new Vector3(0, 0, zVal);
            this.transform.eulerAngles = rot;

            zVal += mod;
            if (zVal >= maxTilt && zVal < maxTilt + 1.0f)
            {
                mod = -0.05f;
            }
            else if (zVal < -maxTilt && zVal > -(maxTilt + 1.0f))
            {
                mod = 0.05f;
            }
        }
    }
}
