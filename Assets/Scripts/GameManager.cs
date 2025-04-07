using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

/// <summary>
/// Enum representing the possible choices in the game.
/// </summary>
public enum Choice
{
    Rock,
    Paper,
    Scissors,
    None
}

/// <summary>
/// GameManager for Rock-Paper-Scissors game, Manages player and computer choices, and determines the winner.
/// </summary>
public class GameManager : MonoBehaviour
{
    public Text playerChoiceText;
    public Text computerChoiceText;
    public Text resultText;
    public Button shootButton;
    public Button replayButton;
    public Button closeButton;
    private Choice playerChoice = Choice.None;
    private Choice computerChoice = Choice.None;
    // / Dictionary to hold winning choices
    private Dictionary<Choice, Choice> winningChoices = new Dictionary<Choice, Choice>()
    {
        { Choice.Rock, Choice.Scissors },
        { Choice.Scissors, Choice.Paper },
        { Choice.Paper, Choice.Rock }
    };

    /// <summary>
    /// Player selects a choice (Rock, Paper, or Scissors)
    /// </summary>
    /// <param name="choice"></param>

    public void PlayerSelect(int choice)
    {
        if (playerChoice != Choice.None) return; // Anti-cheat: Prevent changing choice

        playerChoice = (Choice)choice;
        playerChoiceText.text = "You chose: " + playerChoice.ToString();
    }

    /// <summary>
    /// Computer generates a random choice and determines the winner
    /// </summary>
    public void Shoot()
    {
        if (playerChoice == Choice.None) return;

        // Generate a random choice for the computer
        computerChoice = (Choice)Random.Range(0, 3);
        computerChoiceText.text = "Computer chose: " + computerChoice.ToString();

        // Determine the winner
        if (playerChoice == computerChoice)
        {
            resultText.text = "It's a Tie!";
        }
        else if (winningChoices[playerChoice] == computerChoice)
        {
            resultText.text = "You Win!";
        }
        else
        {
            resultText.text = "You Lose!";
        }

        // Disable selection and enable Replay
        shootButton.interactable = false;
        replayButton.interactable = true;
    }


    public void Replay()
    {
        playerChoice = Choice.None;
        computerChoice = Choice.None;
        playerChoiceText.text = "Your choice: ";
        computerChoiceText.text = "Computer choice: ";
        resultText.text = "Result: ";
        shootButton.interactable = true;
        replayButton.interactable = false;
    }


    /// <summary>
    /// Close the game and return to the Main Menu/Menu Scene
    /// </summary>
    public void Close()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
