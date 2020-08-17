using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public bool isHorizontal;
    public abstract void Interact();

    public void Disable()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
