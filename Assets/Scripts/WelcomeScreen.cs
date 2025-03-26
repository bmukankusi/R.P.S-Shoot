using UnityEngine;
using UnityEngine.SceneManagement;

public class WelcomeScreen : MonoBehaviour
{
    private void Start()
    {
        Invoke("LoadMainMenu", 3f); // Wait for 3 seconds
    }

    void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
