using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnDelay;
    public GameObject[] enemyPrefabs;

    void Start()
    {
        StartCoroutine(EnemySpawning());    
    }
    IEnumerator EnemySpawning()
    {
        while (GameManager.IsPlaying)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    void SpawnEnemy()
    {
        AudioManager.Instance.PlaySFX("Enemy_Spawn");

        GameObject e = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(e, transform.position, e.transform.rotation);
    }
}
