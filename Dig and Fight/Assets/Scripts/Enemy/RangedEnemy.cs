using UnityEngine;

public class RangedEnemy : Enemy
{
    [Header("Ranged Variables")]
    public float viewRayDist;
    public float shootRayDist;

    public GameObject projectilePrefab;
    public LayerMask layersOfInterest;
    public LayerMask playerLayer;

    Vector2 viewDir;

    PlayerController target;

    void Start()
    {
        target = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (!GameManager.IsPlaying)
            return;

        viewDir = (target.transform.position - transform.position).normalized;
        RaycastHit2D viewHitInfo = Physics2D.Raycast(transform.position, viewDir, viewRayDist, layersOfInterest);
        RaycastHit2D shootHitInfo = Physics2D.Raycast(transform.position, viewDir, shootRayDist, playerLayer);

        // If enemy doesn't see the player //
        if (shootHitInfo.collider == null)
        {
            FollowPlayer();
            ResetDelays();
        }

        // if player is front of enemy //    
        else
        {
            if (ad >= attackDelay)
                ShootProjectile();
            else
                ad += Time.deltaTime;

            dd = 0;
        }

        // if in front of enemy is block //
        if (viewHitInfo.collider != null && viewHitInfo.collider.CompareTag("Block"))
        {
            if (dd >= digDelay)
                DestroyTile(GetTiledPosition(viewHitInfo.point));
            else
                dd += Time.deltaTime;

            ad = 0;
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }
    void ShootProjectile()
    {
        float rotZ = Mathf.Atan2(viewDir.y, viewDir.x) * Mathf.Rad2Deg - 45f;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotZ);

        AudioManager.Instance.PlaySFX("Enemy_Shoot");

        Instantiate(projectilePrefab, transform.position, rotation);
        ad = 0;
    }

    Vector2 GetTiledPosition(Vector2 raw)
    {
        float x = raw.x + (viewDir.x / 5f);
        float y = raw.y + (viewDir.y / 5f);

        Debug.DrawLine(transform.position, new Vector2(x, y), Color.green);

        return new Vector2(x, y);
    }
}
