using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject howToPlayPanel;
    public GameObject aboutPanel;
    public GameObject StartButton;

    private void Start()
    {
        ShowMainPanel(); // Ensure the main menu is visible at start
    }

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
