using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    private AudioSource backgroundMusic;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persist across scenes
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Find and keep reference to background music
        backgroundMusic = GameObject.FindWithTag("BackgroundMusic")?.GetComponent<AudioSource>();
        LoadAudioSettings();
    }

    // Set Background Music Volume
    public void SetMusicVolume(float volume)
    {
        if (backgroundMusic != null)
        {
            backgroundMusic.volume = volume;
        }
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    // Mute/Unmute Sound Effects
    public void ToggleSFX(bool isOn)
    {
        //Debug.Log("Applying SFX Toggle: " + isOn); 

        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
        AudioSource[] sfxSources = FindObjectsOfType<AudioSource>();

        foreach (AudioSource sfx in sfxSources)
        {
            if (sfx.CompareTag("SFX"))
            {
                Debug.Log("Muting SFX: " + sfx.gameObject.name + " | Muted: " + !isOn);
                sfx.mute = !isOn;
            }
        }
    }


    // Load Settings on Startup
    private void LoadAudioSettings()
    {
        float savedVolume = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SetMusicVolume(savedVolume);

        bool isSfxOn = PlayerPrefs.GetInt("SFX", 1) == 1;
        ToggleSFX(isSfxOn);
    }
}
