using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Transform weaponTrans;
    public Transform pickaxeTrans;

    public Tool pickaxe;
    public Tool weapon;

    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            pickaxeTrans.rotation = Quaternion.Euler(Vector3.forward * GetToolZRotation());

            UseTool(pickaxe);
        }

        if (Input.GetMouseButtonDown(0))
        {
            weaponTrans.rotation = Quaternion.Euler(Vector3.forward * GetToolZRotation());

            UseTool(weapon);
        }
    }

    void FixedUpdate()
    {
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

    void UseTool(Tool tool)
    {
        tool.Interact();
    }

    public float GetToolZRotation()
    {
        // Calculating Z rotation //
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        return (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) + weapon.zOffset;
    }
}
