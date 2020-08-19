using UnityEngine;

public class Rocket : Projectile
{
    [Header("Rocket Variables")]
    public GameObject subProjectilePrefab;
    public int projCount;
    public override void OnCollide(Collider2D hitCollider)
    {
        float deltaZ = (2 * Mathf.PI / projCount) * Mathf.Rad2Deg;
        for (int i = 0; i < projCount; i++)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, deltaZ * i);
            Instantiate(subProjectilePrefab, transform.position, rotation);
        }

        AudioManager.Instance.PlaySFX("Explosion");
        EffectsEmitter.Emit("Small_Red_Explosion", transform.position);
        base.OnCollide(hitCollider);
    }
}
