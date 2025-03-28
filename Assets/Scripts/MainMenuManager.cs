using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// MenuManager script to manage the Main Menu UI
/// Manage the visibility of different panels in the Main Menu
/// </summary>
public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject howToPlayPanel;
    public GameObject aboutPanel;
    public GameObject StartButton;

    // Ensure the main menu is visible at start
    private void Start()
    {
        ShowMainPanel(); 
    }

    /// <summary>
    /// Start the game by loading the Game Scene
    /// </summary>
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // Load the game scene
    }

    public void ShowMainPanel()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void ShowSettingsPanel()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void ShowHowToPlayPanel()
    {
        mainPanel.SetActive(false);
        howToPlayPanel.SetActive(true);
    }

    public void ShowAboutPanel()
    {
        mainPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }
}
