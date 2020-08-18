using UnityEngine;

public class PUGun : MonoBehaviour, IPowerUp
{
    public ToolData[] guns;

    public void Upgrade()
    {
        GameManager.Instance.player.SetNewCustomTool(guns[Random.Range(0, guns.Length)]);

        Destroy(gameObject);
    }
}