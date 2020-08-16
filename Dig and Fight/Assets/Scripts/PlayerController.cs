using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    public Transform handTrans;
    [HideInInspector] public Tool nowTool;

    Rigidbody2D rb;
    Animator animator;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            UseTool(nowTool);
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

    #region Tools

    void UseTool(Tool tool)
    {
        if (tool == null)
            return;

        handTrans.rotation = GetHandRotation();

        //Debug.Log(handTrans.rotation.eulerAngles.z);
        if (!tool.isHorizontal)
            if (handTrans.rotation.eulerAngles.z > 90f && handTrans.rotation.eulerAngles.z < 270f)
                tool.transform.localScale = new Vector3(1f, -1f, 1f);
            else
                tool.transform.localScale = Vector3.one;

        tool.Interact();
    }

    // Respawning Tool on change (from hotkeys) //
    public void ReplaceTool(ToolData newToolData)
    {
        RemoveTool();
        if (newToolData == null)
            return;

        SpawnTool(newToolData);
    }

    void SpawnTool(ToolData toolData)
    {
        GameObject toolGO = Instantiate(toolData.prefab, handTrans.transform.position, Quaternion.identity, handTrans);
        toolGO.transform.localRotation = Quaternion.Euler(Vector3.forward * toolData.zOffset);

        nowTool = toolGO.GetComponent<Tool>();
    }

    void RemoveTool()
    {
        if (nowTool != null)
            Destroy(nowTool.gameObject);
    }

    // Calculating hand rotation relative to mouse pos //
    public Quaternion GetHandRotation()
    {
        Vector2 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0f, 0f, rotZ);
    }
    #endregion
}
