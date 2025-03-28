using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// Simple script to load the Main Menu after a delay
/// </summary>
public class WelcomeScreen : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadMainMenu", 2.5f); // Wait for 3 seconds
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
