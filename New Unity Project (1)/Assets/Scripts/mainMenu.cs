using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class mainMenu : MonoBehaviour
{
    
   public void MainMenu()
    {
        Debug.Log("I'm clicking");
        SceneManager.LoadScene("Game");
    }
}
