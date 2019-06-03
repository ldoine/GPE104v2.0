using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    //This float is used to set the players movement speed
    public float moveSpeed = 5f;
    // Max speed of the player
    public float maxSpeed = 14f;
    // rotation speed of player
    float rotSpeed = 180f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //These if statements are used to move the player when either the "A" key or "D" key are pressed
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }
        // Gets rotation quaternion
        Quaternion rot = transform.rotation;

        // Gets the Z euler angle
        float z = rot.eulerAngles.z;

        // Change the z angle on input
        z -= Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;

        // Recreate the quaternion
        rot = Quaternion.Euler(0, 0, z);

        // Feed the quaternion into the rotation
        transform.rotation = rot;

        // Move the ship
        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;
    }
}
