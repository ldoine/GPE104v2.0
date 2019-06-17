using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    // Allows me to set the health for different objects
    public int health = 1;
    // Sets a period of invulnerablilty after the player is hit
    float invulnTimer = 0;

    // Allows me to customize what ships have invulnerability timers
    public float invulnPeriod = 0;

    int correctLayer;

    //public float invulnAnimTimer=0;

    SpriteRenderer spriteRend;

    private void Start()
    {
        correctLayer = gameObject.layer;
        // This only gets the renderer on the parent object.
        // So it doesn't work for children such as "enemy01"
        spriteRend = GetComponent<SpriteRenderer>();

        if (spriteRend == null)
        {
            spriteRend = transform.GetComponentInChildren<SpriteRenderer>();

            if (spriteRend == null)
            {
                Debug.LogError("Object '" + gameObject.name + "' has no sprite renderer.");
            }
        }
    }

    void OnTriggerEnter2D()
    {
        Debug.Log("Trigger!");
        if (invulnTimer <= 0)
        {
            // When a trigger happens lose 1 health
            health--;
            // The amount of time the player is invulnerable in secconds 
            invulnTimer = 2f;
            gameObject.layer = 10;
        }

    }

    void Update()
    {
        // Takes away the players invulnerability 
        if (invulnTimer > 0)
        {
            invulnTimer -= Time.deltaTime;

            if (invulnTimer <= 0)
            {
                gameObject.layer = correctLayer;
                if (spriteRend != null)
                {
                    spriteRend.enabled = true;
                }
                else
                {
                    if (spriteRend != null)
                    {
                        spriteRend.enabled = !spriteRend.enabled;
                    }
                }

            }
        }
        // If health is 0 you die
        if (health <= 0)
        {
            Die();
        }
    }
    // Destroys objects when they have lost all health
    void Die()
    {
        Destroy(gameObject);
    }

}

