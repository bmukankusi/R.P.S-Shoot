using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("UI Elements")]
    public Button musicButton;
    public Button soundEffectsButton;
    public Button backgroundColorButton;

    public Image musicButtonIcon;
    public Image soundEffectsButtonIcon;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    public Sprite soundOnSprite;
    public Sprite soundOffSprite;

    [Header("Background Colors")]
    public Color[] backgroundColors = { Color.black, Color.white, Color.green, new Color(1f, 0.5f, 0f) }; // Black, White, Green, Orange
    private int currentColorIndex = 0;

    private const string MUSIC_PREF = "MusicMuted";
    private const string SOUND_PREF = "SoundMuted";
    private const string COLOR_PREF = "BackgroundColorIndex";

    private void Start()
    {
        // Load saved settings
        bool isMusicMuted = PlayerPrefs.GetInt(MUSIC_PREF, 0) == 1;
        bool isSoundMuted = PlayerPrefs.GetInt(SOUND_PREF, 0) == 1;
        currentColorIndex = PlayerPrefs.GetInt(COLOR_PREF, 0);

        UpdateMusicUI(isMusicMuted);
        UpdateSoundUI(isSoundMuted);
        ApplyBackgroundColor();

        // Add button listeners
        musicButton.onClick.AddListener(ToggleMusic);
        soundEffectsButton.onClick.AddListener(ToggleSoundEffects);
        backgroundColorButton.onClick.AddListener(ChangeBackgroundColor);
    }

    private void ToggleMusic()
    {
        bool isMuted = PlayerPrefs.GetInt(MUSIC_PREF, 0) == 1;
        isMuted = !isMuted;
        PlayerPrefs.SetInt(MUSIC_PREF, isMuted ? 1 : 0);
        PlayerPrefs.Save();

        UpdateMusicUI(isMuted);
    }

    private void ToggleSoundEffects()
    {
        bool isMuted = PlayerPrefs.GetInt(SOUND_PREF, 0) == 1;
        isMuted = !isMuted;
        PlayerPrefs.SetInt(SOUND_PREF, isMuted ? 1 : 0);
        PlayerPrefs.Save();

        UpdateSoundUI(isMuted);
    }

    private void ChangeBackgroundColor()
    {
        currentColorIndex = (currentColorIndex + 1) % backgroundColors.Length;
        PlayerPrefs.SetInt(COLOR_PREF, currentColorIndex);
        PlayerPrefs.Save();

        ApplyBackgroundColor();
    }

    private void UpdateMusicUI(bool isMuted)
    {
        musicButtonIcon.sprite = isMuted ? musicOffSprite : musicOnSprite;
        AudioListener.pause = isMuted; // Mutes all background music
    }

    private void UpdateSoundUI(bool isMuted)
    {
        soundEffectsButtonIcon.sprite = isMuted ? soundOffSprite : soundOnSprite;
        AudioListener.volume = isMuted ? 0f : 1f; // Mutes all sound effects
    }

    private void ApplyBackgroundColor()
    {
        Camera.main.backgroundColor = backgroundColors[currentColorIndex];
    }
}
