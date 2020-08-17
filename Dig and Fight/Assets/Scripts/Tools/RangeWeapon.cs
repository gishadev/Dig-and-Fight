using UnityEngine;

public class RangeWeapon : Tool
{
    public Transform shotPos;
    public GameObject projectilePrefab;

    [Header("Properties")]
    public int ammo;

    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public override void Interact()
    {
        animator.SetTrigger("Interact");
        Shoot();
    }

    void Shoot()
    {
        float rotZ = Mathf.Atan2(-shotPos.up.y, -shotPos.up.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(0f, 0f, rotZ);

        Instantiate(projectilePrefab, shotPos.position, rotation);
        ammo--;

        if (ammo <= 0)
            GameManager.Instance.player.DestroyCustomTool();
    }
}
