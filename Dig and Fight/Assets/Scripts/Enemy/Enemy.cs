using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    [Header("Default Vars")]
    public int health;
    public float moveSpeed;

    public void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDamage()
    {
        health--;

        if (health <= 0)
            Die();
    }
}
