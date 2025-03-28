using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// SettingsManager script to manage audio settings, background color, and save settings to PlayerPrefs
/// </summary>
public class SettingsManager : MonoBehaviour
{
    [Header("Audio Settings")]
    public Slider musicSlider; 
    public Toggle sfxToggle;   

    [Header("Background Settings")]
    public GameObject[] backgroundPanels;
    public Button backgroundChangeButton; 

    
    private int currentColorIndex = 0;

    private AudioSource backgroundMusic; 

    void Start()
    {
        // Find and Assign Background Music
        backgroundMusic = GameObject.FindWithTag("BackgroundMusic")?.GetComponent<AudioSource>();

        //  Load Previous Settings
        LoadSettings();

        //  Add Click Listener for Background Color Change
        if (backgroundChangeButton != null)
            backgroundChangeButton.onClick.AddListener(ChangeBackgroundColor);

        //  Attach Slider Listener
        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener(SetMusicVolume);
    }

    /// <summary>
    /// Set Music Volume, and Save to PlayerPrefs
    /// </summary>
    /// <param name="volume"></param>
    public void SetMusicVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;
        }
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Enable/Disable Sound Effects
    public void ToggleSFX(bool isOn)
    {
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
    }

    // Background colors
    private Color[] backgroundColors =
    {
        Color.white,
        new Color(0.0f, 0.5f, 0.0f), 
        new Color(1.0f, 0.65f, 0.0f) 
    };
    // Cycle Background Colors and Apply to All Panels
    public void ChangeBackgroundColor()
    {
        currentColorIndex = (currentColorIndex + 1) % backgroundColors.Length;

        foreach (GameObject panel in backgroundPanels)
        {
            if (panel != null)
            {
                panel.GetComponent<Image>().color = backgroundColors[currentColorIndex]; // Apply to All Panels
            }
        }

        PlayerPrefs.SetInt("BackgroundColorIndex", currentColorIndex);
    }

    // Load Previous Settings
    private void LoadSettings()
    {
        // Load Music Volume
        if (musicSlider != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
            musicSlider.value = savedVolume;
            if (backgroundMusic != null) backgroundMusic.volume = savedVolume;
        }

        // Load Sound Effects Toggle
        if (sfxToggle != null)
        {
            sfxToggle.isOn = PlayerPrefs.GetInt("SFX", 1) == 1;
        }

        // Load Background Color
        currentColorIndex = PlayerPrefs.GetInt("BackgroundColorIndex", 0);
        foreach (GameObject panel in backgroundPanels)
        {
            if (panel != null)
            {
                panel.GetComponent<Image>().color = backgroundColors[currentColorIndex];
            }
        }
    }
}
