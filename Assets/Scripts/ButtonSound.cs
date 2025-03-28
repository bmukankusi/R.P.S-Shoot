using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ButtonSound script to play a sound effect when a button is clicked, using an AudioSource
/// </summary>
public class ButtonSound : MonoBehaviour
{
    public AudioClip clickSound; // Assign in Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>(); // Finds the AudioSource in the scene
    }

    /// <summary>
    /// Play sound effect when button is clicked
    /// </summary>

    public void PlaySound()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound); // Play sound effect once
        }
    }
}
