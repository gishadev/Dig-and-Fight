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
        while (true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    void SpawnEnemy()
    {
        GameObject e = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Instantiate(e, transform.position, e.transform.rotation);
    }
}
