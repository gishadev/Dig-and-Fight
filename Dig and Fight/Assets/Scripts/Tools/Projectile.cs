using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeTime = 5f;
    public float flySpeed = 3f;

    public LayerMask projMask;

    Vector2 direction;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

        direction = transform.InverseTransformDirection(transform.up);
    }

    void Update()
    {
        transform.Translate(direction * flySpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, 0.5f, projMask);

        if (hitInfo.collider != null)
            DestroyProjectile();
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
