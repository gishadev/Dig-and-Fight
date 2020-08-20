using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{
    public int maxHealth = 3;
    public float moveSpeed;

    public int Health
    {
        get { return health; }
        set
        {
            health = Mathf.Clamp(value, 0, 3);
            UIManager.Instance.healthUI.UpdateHealthUI(health);
        }
    }
    int health;

    public Transform handTrans;

    public Tool[] tools;
    public Tool nowTool;

    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        Health = maxHealth;
    }

    void Update()
    {
        if (!GameManager.IsPlaying)
            return;

        if (Input.GetMouseButtonDown(0))
            UseTool(nowTool);
    }

    void FixedUpdate()
    {
        if (!GameManager.IsPlaying)
            return;

        Movement();
    }

    void Movement()
    {
        // Movement //
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        rb.velocity = input * moveSpeed * Time.deltaTime;

        // Animation //
        if (input.magnitude > 0)
            animator.SetBool("Moving", true);
        else
            animator.SetBool("Moving", false);
    }

    #region Tools

    void UseTool(Tool tool)
    {
        if (tool == null)
            return;

        handTrans.rotation = GetHandRotation();

        if (!tool.isHorizontal)
            if (handTrans.rotation.eulerAngles.z > 90f && handTrans.rotation.eulerAngles.z < 270f)
                tool.transform.localScale = new Vector3(1f, -1f, 1f);
            else
                tool.transform.localScale = Vector3.one;

        tool.Interact();
    }

    public void ChangeTool(int index)
    {
        // Disable Old Tool //
        if (nowTool != null)
            nowTool.Disable();

        // Enable New Tool //
        nowTool = tools[index];

        // If Range Weapon => Show Ammo //
        if (tools[2] == null)
            return;
        CheckForRanged();
    }

    void CheckForRanged()
    {
        if (nowTool == tools[2])
            UIManager.Instance.ammoUI.UpdateAmmoUI(nowTool.GetComponent<RangeWeapon>().ammo);
        else
            UIManager.Instance.ammoUI.Disable();
    }

    public void DestroyCustomTool()
    {
        if (tools[2] == null)
            return;

        if (nowTool == tools[2])
            nowTool = null;

        Destroy(tools[2].gameObject);

        Hotbar.Instance.RemoveToolData(2);
    }

    public void SetNewCustomTool(ToolData data)
    {
        DestroyCustomTool();
        Hotbar.Instance.AddNewToolData(2, data);

        Tool newTool = Instantiate(data.prefab, handTrans.transform.position, Quaternion.identity, handTrans).GetComponent<Tool>();
        newTool.transform.localRotation = Quaternion.Euler(Vector3.forward * data.zOffset);

        tools[2] = newTool;

        if (nowTool == null)
        {
            nowTool = newTool;
            ChangeTool(2);
        }

        CheckForRanged();
    }

    // Calculating hand rotation relative to mouse pos //
    public Quaternion GetHandRotation()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, rotZ);
    }


    #endregion

    #region Actions
    public void TakeDamage()
    {
        Health--;

        AudioManager.Instance.PlaySFX("Player_GetDmg");

        if (Health <= 0)
            Die();
    }

    public void Die()
    {
        GameManager.Instance.PauseGame();
        gameObject.SetActive(false);

        UIManager.Instance.ActivateDeathMenu();
    }

    #endregion
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("PowerUp"))
        {
            other.GetComponent<IPowerUp>().Upgrade();
            AudioManager.Instance.PlaySFX("PowerUp");
        }
    }
}
