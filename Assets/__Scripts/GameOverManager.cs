using UnityEngine;
using UnityEngine.SceneManagement; // For scene management
using UnityEngine.UI; // For UI components

public class GameOverManager : MonoBehaviour
{
    public void TryAgain()
    {
        // Reload the current scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        // Quit the application (will not work in the editor)
        Application.Quit();
    }
}