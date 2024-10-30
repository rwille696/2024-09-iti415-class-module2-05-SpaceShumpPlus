using UnityEngine;
using UnityEngine.UI; // Include this if you are using UI Text or TextMeshPro
using TMPro; // Include this if you're using TextMeshPro

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 120; // 2 minutes in seconds
    public TextMeshProUGUI timerText; // Link this to your UI Text or TextMeshPro in the Inspector
    public bool timerIsRunning = false;

    private void Start()
    {
        // Start the timer
        timerIsRunning = true;
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
                StopGame();
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

    private void StopGame()
    {
        // You can implement your game stop logic here
        // For example, you can display a game over message or stop all player actions
        Debug.Log("Time's up! Game Over!");
        // Optionally, you can load a game over scene or quit the application
        // UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
        // Application.Quit();
    }
}