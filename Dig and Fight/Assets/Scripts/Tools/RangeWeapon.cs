using UnityEngine;

public class RangeWeapon : Tool
{
    public Transform shotPos;
    [Space]
    public GameObject projectilePrefab;
    public int maxAmmo;

    int nowAmmo;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        nowAmmo = maxAmmo;    
    }

    public override void Interact()
    {
        animator.SetTrigger("Interact");
        Shoot();
    }

    void Shoot()
    {
        Instantiate(projectilePrefab, shotPos.position, shotPos.rotation);
    }
}
