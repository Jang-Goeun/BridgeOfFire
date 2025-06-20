using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    bool shouldFollow = false;
    void Start()
    {
        player = GameObject.Find("cat");
    }

    void Update()
    {
        Vector3 playerPos = this.player.transform.position;

        if (!shouldFollow && playerPos.x > 0f && playerPos.x < 45)
        {
            shouldFollow = true;
        }
        
        if(shouldFollow && (playerPos.x < 0f || playerPos.x > 45))
        {
            shouldFollow = false;
        }

        if (shouldFollow)
        {
            transform.position = new Vector3(playerPos.x, transform.position.y, transform.position.z);
        }
    }
}
