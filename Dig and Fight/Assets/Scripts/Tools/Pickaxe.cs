using UnityEngine;

public class Pickaxe : Tool
{
    public float radius;
    public LayerMask blockLayer;

    // For Checking //
    //bool isReadyToDig = false;
    Collider2D tileCollider;
    Vector2 mousePosInWorld;

    Animator animator;
    BlockHighlight highlight;

    void Awake()
    {
        animator = GetComponent<Animator>();
        highlight = FindObjectOfType<BlockHighlight>();
    }

    void Update()
    {
        UpdateHighlight();
    }

    public override void Interact()
    {
        animator.SetTrigger("Interact");
        Dig();
    }

    void Dig()
    {
        if (tileCollider != null)
            TilemapEditor.Instance.DeleteTile(mousePosInWorld);
    }

    void UpdateHighlight()
    {
        mousePosInWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (!IsInRadius(mousePosInWorld))
        {
            highlight.DisableHighlight();
            return;
        }

        tileCollider = Physics2D.OverlapCircle(mousePosInWorld, 0.00001f, blockLayer);

        if (tileCollider != null)
        {
            Vector2 position = new Vector2(Mathf.Floor(mousePosInWorld.x) + 0.5f, Mathf.Floor(mousePosInWorld.y) + 0.5f);

            highlight.SetHighlight(position);
        }
        else
            highlight.DisableHighlight();
    }

    bool IsInRadius(Vector2 pos)
    {
        return Vector2.Distance(GameManager.Instance.player.transform.position, pos) < radius;
    }
}
