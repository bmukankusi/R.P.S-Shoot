using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;
    public Dropdown backgroundDropdown;

    private void Start()
    {
        LoadSettings();
    }

    public void ToggleMusic(bool isOn)
    {
        PlayerPrefs.SetInt("Music", isOn ? 1 : 0);
        // Implement audio control here
    }

    public void ToggleSFX(bool isOn)
    {
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
        // Implement SFX control here
    }

    public void ChangeBackground(int index)
    {
        PlayerPrefs.SetInt("Background", index);
        // Change background color here
    }

    private void LoadSettings()
    {
        musicToggle.isOn = PlayerPrefs.GetInt("Music", 1) == 1;
        sfxToggle.isOn = PlayerPrefs.GetInt("SFX", 1) == 1;
        backgroundDropdown.value = PlayerPrefs.GetInt("Background", 0);
    }
}
