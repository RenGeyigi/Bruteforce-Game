using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to the UI Text element to display the score

    void Start()
    {
        // Display the final score
        scoreText.text = "Score: " + Skor.Score.ToString();
    }

    // Method to handle the restart button click
    public void OnRestartButtonClicked()
    {
        // Reset the score
        Skor.Score = 0;
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Method to handle the main menu button click
    public void OnMainMenuButtonClicked()
    {
        // Load the main menu scene
        SceneManager.LoadScene("Giris"); // Make sure "MainMenu" is added to the build settings
    }
}
