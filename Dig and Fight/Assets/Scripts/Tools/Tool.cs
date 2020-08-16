using UnityEngine;

public abstract class Tool : MonoBehaviour
{
    public bool isHorizontal;
    public abstract void Interact();
}
