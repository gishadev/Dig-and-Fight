using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { private set; get; }
    #endregion

    [Header("Game Objects")]
    public PlayerController player;
    public EnemySpawner[] enemySpawners;
    public GameObject[] powerUps;

    [Header("Game Variables")]
    [Range(0f, 100f)] public float enemySpawnerPercentage = 15f;
    [Range(0f, 100f)] public float spawnPowerUpPercentage = 15f;
    public float maxTimeToHit;
    public float TimeToHit
    {
        get { return timeToHit; }
        set
        {
            timeToHit = Mathf.Clamp(value, 0f, maxTimeToHit);
            UIManager.Instance.timerUI.UpdateTimerUI(timeToHit, maxTimeToHit);
            if (timeToHit <= 0)
                RestartGame();
        }
    }
    float timeToHit;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        TimeToHit = maxTimeToHit;    
    }

    void Update()
    {
        TimeToHit -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.R))
            RestartGame();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void ResetTimer()
    {
        TimeToHit = maxTimeToHit;
    }

    #region Spawners
    public bool IsSetEnemySpawner()
    {
        return Random.Range(0f, 100f) < enemySpawnerPercentage;
    }

    public void SpawnEnemySpawner(Vector2 position)
    {
        Instantiate(enemySpawners[Random.Range(0, enemySpawners.Length)], position, Quaternion.identity);
    }
    #endregion

    #region PowerUps
    public bool IsSetPowerUp()
    {
        return Random.Range(0f, 100f) < spawnPowerUpPercentage;
    }

    public void SpawnPowerUp(Vector2 position)
    {
        Instantiate(powerUps[Random.Range(0, powerUps.Length)], position, Quaternion.identity);
    }
    #endregion
}
