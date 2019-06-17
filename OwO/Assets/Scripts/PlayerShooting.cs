using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;

    // Sets the cooldown timer in between shots
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;
        // Gets the players input for shooting
        if (Input.GetButton("Fire1") && cooldownTimer <= 0)
        {
            // Shoot
            // Logs each shot for the purpose of testing
            // Debug.Log("Shot");
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * new Vector3(0, 0.5f, 0);

            Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
        }
    }
}