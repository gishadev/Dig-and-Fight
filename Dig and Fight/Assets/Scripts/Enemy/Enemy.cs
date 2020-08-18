using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Default Variables")]
    public int health;
    public float moveSpeed;

    public float digDelay;
    public float attackDelay;

    [HideInInspector] public float dd = 0f;
    [HideInInspector] public float ad = 0f;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
            Die();

        GameManager.Instance.ResetTimer();
    }

    public void DestroyTile(Vector2 hitPoint)
    {
        TilemapEditor.Instance.DeleteTile(hitPoint);
        dd = 0;
    }


    public void ResetDelays()
    {
        ad = 0;
        dd = 0;
    }
}
