using UnityEngine;

public class Pickaxe : Tool
{
    public float radius;
    public LayerMask blockLayer;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        animator.SetTrigger("Interact");
        Dig();
    }

    void Dig()
    {
        Vector2 mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collider;

        if (!IsInRadius(mousePosInWorld))
            return;

        collider = Physics2D.OverlapCircle(mousePosInWorld, 0.1f, blockLayer);

        if (collider != null)
            TilemapEditor.Instance.RemoveTile(mousePosInWorld);
    }

    bool IsInRadius(Vector2 pos)
    {
        return Vector2.Distance(GameManager.Instance.player.transform.position, pos) < radius;
    }
}
