using UnityEngine;

public class Bullet : Projectile
{
    public override void OnCollide(Collider2D hitCollider)
    {
        if (hitCollider.CompareTag("Enemy") || hitCollider.CompareTag("Player"))
            hitCollider.GetComponent<IDamageable>().TakeDamage();

        base.OnCollide(hitCollider);
    }
}
