using UnityEngine;
using UnityEngine.UI; // Include this if you are using UI Text or TextMeshPro
using TMPro; // Include this if you're using TextMeshPro
using UnityEngine.SceneManagement; // For scene management

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 120; // 2 minutes in seconds
    public TextMeshProUGUI timerText; // Link this to your UI Text or TextMeshPro in the Inspector
    public bool timerIsRunning = false;

    private int targetScore = 2000; // The target score to achieve
    private ScoreManager scoreManager; // Reference to your ScoreManager script

    private void Start()
    {
        // Start the timer
        timerIsRunning = true;
        scoreManager = FindObjectOfType<ScoreManager>(); // Find the ScoreManager in the scene
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                EndGame();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        // Convert time remaining to minutes and seconds
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        // Check if the player achieved the target score
        if (scoreManager.currentScore >= targetScore)
        {
            Debug.Log("Congratulations! You reached the target score.");
            // Optionally, implement victory logic here
        }
        else
        {
            Debug.Log("Time's up! Game Over! You didn't reach the target score.");
            // Here you can load a game over scene or show a try again UI
            // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
            // Optionally, you could call a method to show a try again UI
            ShowTryAgainUI();
        }
    }

    private void ShowTryAgainUI()
    {
        // Implement your logic to show a UI for trying again
        // For example, display a Game Over panel with a "Try Again" button
        // This is just a placeholder for demonstration
        Debug.Log("Display Try Again UI");
    }
}