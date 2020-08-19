using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Projectile Variables")]
    public float lifeTime = 5f;
    public float flySpeed = 3f;

    public Transform pivotPoint;
    public LayerMask projMask;

    Vector2 direction;

    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

        direction = transform.InverseTransformDirection(pivotPoint.up);
    }

    void Update()
    {
        transform.Translate(direction * flySpeed * Time.deltaTime);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, direction, 0.25f, projMask);
        if (hitInfo.collider != null)
            OnCollide(hitInfo.collider);
    }

    public virtual void OnCollide(Collider2D hitCollider)
    {
        DestroyProjectile();
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
