using UnityEngine;
using TMPro; // TextMeshPro for better text rendering

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance; // Singleton instance for easy access
    public TextMeshProUGUI scoreText; // Link this to your UI text element in the Inspector
    public int currentScore { get; private set; } = 0; 

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        UpdateScoreText();
    }

    public void AddScore(int points)
    {
        currentScore += points;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + currentScore;
    }
}
