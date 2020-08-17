using UnityEngine;

public class BlockHighlight : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetHighlight(Vector3 position)
    {
        transform.position = position;

        spriteRenderer.enabled = true;
    }

    public void DisableHighlight()
    {
        spriteRenderer.enabled = false;
    }
}
