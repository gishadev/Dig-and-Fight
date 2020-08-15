using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float worldSize;
    public float followSpeed;

    public Transform target;

    float maxY, maxX;
    float oSize;

    Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    void Start()
    {
        oSize = cam.orthographicSize;
        SetBounds();
    }

    void Update()
    {
        if (target == null)
        {
            Debug.LogError("Target wasn't set.");
            return;
        }
        FollowTarget();
    }

    void FollowTarget()
    {
        float targetX = Mathf.Clamp(target.position.x, -maxX + 1f, maxX);
        float targetY = Mathf.Clamp(target.position.y, -maxY + 1f, maxY);

        Vector3 targetPos = new Vector3(targetX, targetY, -10f);

        transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
    }

    void SetBounds()
    {
        maxY = worldSize - oSize;
        maxX = worldSize - ((float)Screen.width / Screen.height) * oSize;
    }
}
