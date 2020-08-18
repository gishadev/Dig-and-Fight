using System.Collections;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [Header("Melee Variables")]
    public float viewRayDist;
    public LayerMask layersOfInterest;

    Vector2 viewDir;

    PlayerController target;

    void Start()
    {
        target = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        viewDir = (target.transform.position - transform.position).normalized;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, viewDir, viewRayDist, layersOfInterest);

        // If nothing in front of enemy //
        if (hitInfo.collider == null)
        {
            FollowPlayer();
            ResetDelays();
        }

        // Else if something in front of enemy //    
        else
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                if (ad >= attackDelay)
                    DamagePlayer();
                else
                    ad += Time.deltaTime;

                dd = 0;
            }
            else if (hitInfo.collider.CompareTag("Block"))
            {
                if (dd >= digDelay)
                    DestroyTile(GetTiledPosition(hitInfo.point));
                else
                    dd += Time.deltaTime;

                ad = 0;
            }
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
    }

    void DamagePlayer()
    {
        target.TakeDamage();
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
