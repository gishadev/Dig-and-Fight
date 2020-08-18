using UnityEngine;

public class RangeWeapon : Tool
{
    [Header("Range Variables")]
    public Transform shotPos;
    public GameObject projectilePrefab;

    public int ammo;
    public int projCount;
    public float spread;

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
        float initRotZ = Mathf.Atan2(-shotPos.up.y, -shotPos.up.x) * Mathf.Rad2Deg;

        if (projCount == 1)
            spread = 0;

        for (int i = 0; i < projCount; i++)
        {
            float rotZ = initRotZ + Random.Range(-spread, spread);
            Quaternion rotation = Quaternion.Euler(0f, 0f, rotZ);
            Instantiate(projectilePrefab, shotPos.position, rotation);
        }

        ammo--;
        
        if (ammo <= 0)
        {
            GameManager.Instance.player.DestroyCustomTool();
            UIManager.Instance.ammoUI.Disable();
        }
        else
            UIManager.Instance.ammoUI.UpdateAmmoUI(ammo);
    }
}
