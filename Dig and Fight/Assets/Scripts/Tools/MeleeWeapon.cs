using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : Tool
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
