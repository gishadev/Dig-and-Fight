using UnityEngine;

public class PUBomb : MonoBehaviour, IPowerUp
{
    public GameObject projectilePrefab;
    public int count;

    public void Upgrade()
    {
        float deltaZ = (2 * Mathf.PI / count) * Mathf.Rad2Deg;
        for (int i = 0; i < count; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, deltaZ * i);
            Instantiate(projectilePrefab, transform.position, rotation);
        }

        ScoreSystem.Instance.AddScore(25);
        Destroy(gameObject);
    }
}

