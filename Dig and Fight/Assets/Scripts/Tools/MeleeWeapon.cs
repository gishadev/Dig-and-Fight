using UnityEngine;

public class MeleeWeapon : Tool
{
    [Header("Melee Variables")]
    public float rayLength;
    public LayerMask enemyLayerMask;

    Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        animator.SetTrigger("Interact");

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, GetDirectionToMouse(), rayLength, enemyLayerMask);

        if (hitInfo.collider != null)
            hitInfo.collider.GetComponent<IDamageable>().TakeDamage();
    }

    Vector2 GetDirectionToMouse()
    {
        return (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
    }
}
