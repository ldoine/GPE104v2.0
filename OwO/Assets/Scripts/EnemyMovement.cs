using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float rotSpeed = 90f;
    Transform player;

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            // Helps the enemies find the players ship
            GameObject go = GameObject.Find("Player");
            if (go != null)
            {
                player = go.transform;
            }
        }

        // At this point, it has either found the player or the player doesn't exist right now

        if (player == null)
            return; // Try again next frame

        // Here it knows that there is a player and should face them

        Vector3 dir = player.position - transform.position;
        dir.Normalize();

        float zAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;

        Quaternion desiredRot = Quaternion.Euler(0, 0, zAngle);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRot, rotSpeed * Time.deltaTime);


    }
}