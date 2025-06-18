using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement; // Import the SceneManagement namespace

public class GameManager : MonoBehaviour
{
    public int score = 0; // Player's score
    public TextMeshProUGUI scoreText; // Reference to the TMP text component
    public TextMeshProUGUI gameOverText; // Reference to the TMP text component for Game Over
    public GameObject restartButton; // Reference to the Restart Button
    public GameObject startButton; // Reference to the Start Button
    public GameObject startText; // Reference to the Start Text
    public AudioClip pointSound; // Sound to play when the score increases
    public AudioClip obstacleHitSound; // Sound to play when player hits obstacle
    private AudioSource audioSource; // AudioSource component to play sounds

    void Start()
    {
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        UpdateScoreText(); // Initialize the score display
        gameOverText.gameObject.SetActive(false); // Hide Game Over text at the start
        restartButton.SetActive(false); // Hide Restart button at the start
        Time.timeScale = 0; // Pause the game at start
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Point"))
        {
            IncreaseScore();
            Destroy(other.gameObject); // Optional: destroy the point object after collision
        }
        else if (other.CompareTag("obstacle"))
        {
            TriggerObstacleEffects(); // Play sound and particles
            StopGame();
        }
    }

    void IncreaseScore()
    {
        score += 1; // Increase the score by 1
        UpdateScoreText(); // Update the score display
        PlayPointSound(); // Play the point sound
        Debug.Log("Score: " + score); // Log the score to the console
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score; // Update the TMP text
        }
    }

    void PlayPointSound()
    {
        if (pointSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(pointSound); // Play the sound effect for scoring
        }
    }

    void StopGame()
    {
        Debug.Log("Game Over! Final Score: " + score); // Log final score
        Time.timeScale = 0; // Pause the game
        ShowGameOverText(); // Show Game Over text
    }

    void ShowGameOverText()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true); // Show the Game Over text
            gameOverText.text = "Game Over!";
        }

        if (restartButton != null)
        {
            restartButton.SetActive(true); // Show the restart button
        }
    }

    void TriggerObstacleEffects()
    {
        // Play obstacle hit sound
        if (obstacleHitSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(obstacleHitSound);
        }
    }

    // New method to start the game
    public void StartGame()
    {
        Time.timeScale = 1; // Resume the game
        if (startButton != null)
        {
            startButton.SetActive(false); // Hide the Start button
        }
        if (startText != null)
        {
            startText.SetActive(false); // Hide the Start text
        }
    }
}