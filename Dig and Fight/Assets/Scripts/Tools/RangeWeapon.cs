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
        float rotZ = Mathf.Atan2(-shotPos.up.y, -shotPos.up.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f,0f, rotZ);

        Instantiate(projectilePrefab, shotPos.position, rotation);
    }
}
