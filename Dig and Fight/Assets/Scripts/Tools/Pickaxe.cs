using UnityEngine;
public class Pickaxe : Tool
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();    
    }

    public override void Interact()
    {
        animator.SetTrigger("Interact");
    }
}
