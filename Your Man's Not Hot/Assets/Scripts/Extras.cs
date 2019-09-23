using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extras : MonoBehaviour
{
    public Vector3 StartPosition;


    private void Awake()
    {
        StartPosition = transform.position;
    }
    // Start is called before the first frame update
    void Update()
    {
        //This disables the game object, in this case the ship
        if (Input.GetKey(KeyCode.Q))
        {
            gameObject.SetActive(false);
        }
        //This will close out of the game
        if (Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Game quit");
            Application.Quit();
        }
        //This will stop all player movement
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position = StartPosition;

        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1) // If movement is not prevented
                Time.timeScale = 0; // prevent movement
            else
                Time.timeScale = 1; // Otherwise allow movement
        }

    }
}
