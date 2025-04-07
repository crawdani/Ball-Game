using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void OpenSettings()
    {
        // Placeholder for future settings implementation
        Debug.Log("Settings clicked");
    }

    public void ShowLeaderboard()
    {
        // Placeholder for future leaderboard implementation
        Debug.Log("Leaderboard clicked");
    }
}
