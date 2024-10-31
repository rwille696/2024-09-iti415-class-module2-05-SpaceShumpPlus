using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public float timeRemaining = 120; 
    public TextMeshProUGUI timerText; 
    public bool timerIsRunning = false;

    public GameObject gameOverPanel; // Reference to the Game Over panel

    private int targetScore = 2000; 
    private ScoreManager scoreManager; 

    private void Start()
    {
        timerIsRunning = true;
        scoreManager = FindObjectOfType<ScoreManager>(); 

        // Make sure the Game Over panel is hidden at the start
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
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
        float minutes = Mathf.FloorToInt(timeRemaining / 60);
        float seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void EndGame()
    {
        if (scoreManager.currentScore >= targetScore)
        {
            Debug.Log("Congratulations! You reached the target score.");
        }
        else
        {
            Debug.Log("Time's up! Game Over! You didn't reach the target score.");

            // Show the Game Over panel
            if (gameOverPanel != null)
            {
                gameOverPanel.SetActive(true);
            }
        }
    }
}