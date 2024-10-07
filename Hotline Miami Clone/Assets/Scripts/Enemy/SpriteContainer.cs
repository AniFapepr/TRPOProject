using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteContainer : MonoBehaviour
{
    public Sprite enemyKnife, enemySMG, enemyUnarmed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
        public Sprite getEnemySprite(string weapon)
        {
            if (weapon == "Mac10")
            {
                return enemySMG;
            }
            else if(weapon == "Bowie")
            {
                return enemyKnife;
            }
            else 
            {
                return enemyUnarmed;

            }
        }
}
