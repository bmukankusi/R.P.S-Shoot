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


    private void Start()
    {
        // Load settings when the settings menu opens
        LoadSettings();

        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener((value) => AudioManager.instance.SetMusicVolume(value));

        if (sfxToggle != null)
            sfxToggle.onValueChanged.AddListener((isOn) => AudioManager.instance.ToggleSFX(isOn));
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

    // Enable/Disable Sound Effects Globally
    public void ToggleSFX(bool isOn)
    {

        //Debug.Log("Applying SFX Toggle: " + isOn); 
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
        ApplySFXSettings(isOn);
    }

    /// <summary>
    /// Apply SFX Settings to All AudioSources with "SFX" Tag
    /// </summary>
    /// <param name="isOn"></param>
    private void ApplySFXSettings(bool isOn)
    {
        AudioSource[] sfxSources = FindObjectsOfType<AudioSource>(); 
        foreach (AudioSource sfx in sfxSources)
        {
            if (sfx.CompareTag("SFX")) // Ensure it's a button sound effect
            {
                sfx.mute = !isOn;
            }
        }
    }


    // Background colors
    private Color[] backgroundColors =
    {
        Color.white,
        new Color(0.0f, 0.5f, 0.0f), //Green
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
