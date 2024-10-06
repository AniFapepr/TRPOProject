using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    Transform player;
    bool followPlayer = true;
    // Use this for initialization
    void Start () 
    {

        player = FindObjectOfType<CharacterMovement>().transform;
        if (player == null) 
        {
        Debug.LogError("Персонаж не найден!");
        }

    }
    // Update is called once per frame
    void Update () 
    {
        if (followPlayer == true) 
        {
            camFollowPlayer();
        }
    }
   
   public void setFollowPlayerStatus(bool var)
   {
    
    this.followPlayer = var;

   }

    void camFollowPlayer()
    {
        Vector3 newPos = new Vector3(player.transform.position.x, player.transform.position.y, this.transform.position.z);
        this.transform.position = newPos;
    }
}
