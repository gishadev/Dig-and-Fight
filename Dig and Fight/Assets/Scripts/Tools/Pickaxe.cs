using UnityEngine;
using UnityEngine.Tilemaps;

public class Pickaxe : Tool
{
    public float rayLength;
    public LayerMask collideableLayer;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        ShootRay();
        animator.SetTrigger("Interact");
    }

    void ShootRay()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, DirToMouse(), rayLength, collideableLayer);

        Debug.DrawRay(transform.position, DirToMouse().normalized * rayLength);

        if (hitInfo.collider != null)
            if (hitInfo.collider.CompareTag("Block"))
            {
                Debug.Log(hitInfo.collider.name);

                TilemapEditor.Instance.RemoveTile(hitInfo.point);
            }
                
    }

    Vector2 DirToMouse()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
    }
}
