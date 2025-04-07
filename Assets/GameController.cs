using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform enemyContainer;

    private float timer;
    private bool isRunning;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        isRunning = true;
        timer = 0f;
        SpawnPlayer();

        // Spawn initial 3 enemies
        for (int i = 0; i < 3; i++)
        {
            SpawnEnemy();
        }

        // Start timed spawning
        StartCoroutine(SpawnEnemiesOverTime());
    }

    void Update()
    {
        if (!isRunning) return;
        timer += Time.deltaTime;
    }

    public void GameOver()
    {
        isRunning = false;
        PlayerPrefs.SetFloat("LastScore", timer);
        PlayerPrefs.SetInt("EnemyCount", enemyContainer.childCount);
        SceneManager.LoadScene("GameOver");
    }

    private void SpawnPlayer()
    {
        Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
    }

    private void SpawnEnemy()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity, enemyContainer);
        enemy.GetComponent<EnemyBall>().velocity = Random.insideUnitCircle.normalized * 3f;
    }

    private IEnumerator SpawnEnemiesOverTime()
    {
        while (isRunning)
        {
            yield return new WaitForSeconds(30f);
            SpawnEnemy();
        }
    }
}
