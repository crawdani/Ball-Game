using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    void Start()
    {
        // Data is still saved in PlayerPrefs if you want to use it later
        float score = PlayerPrefs.GetFloat("LastScore");
        int enemies = PlayerPrefs.GetInt("EnemyCount");
        int finalScore = (int)(score * enemies);

        Debug.Log($"Survived: {score:F2}s | Enemies: {enemies} | Score: {finalScore}");
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Game");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
