using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public Text playerChoiceText;
    public Text computerChoiceText;
    public Text resultText;
    public Button shootButton;
    public Button replayButton;
    public Button closeButton;

    private enum Choice { Rock, Paper, Scissors, None }
    private Choice playerChoice = Choice.None;
    private Choice computerChoice = Choice.None;

    private Dictionary<Choice, Choice> winningChoices = new Dictionary<Choice, Choice>()
    {
        { Choice.Rock, Choice.Scissors },
        { Choice.Scissors, Choice.Paper },
        { Choice.Paper, Choice.Rock }
    };

    public void PlayerSelect(int choice)
    {
        if (playerChoice != Choice.None) return; // Anti-cheat: Prevent changing choice

        playerChoice = (Choice)choice;
        playerChoiceText.text = "You chose: " + playerChoice.ToString();
    }

    public void Shoot()
    {
        if (playerChoice == Choice.None) return;

        // Generate a random choice for the computer
        computerChoice = (Choice)Random.Range(0, 3);
        computerChoiceText.text = "Computer chose: " + computerChoice.ToString();

        // Determine winner
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


    //Close button returns to main menu scene
    public void Close()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
