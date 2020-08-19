using UnityEngine;

public class PUGun : MonoBehaviour, IPowerUp
{
    public ToolData[] guns;

    public void Upgrade()
    {
        GameManager.Instance.player.SetNewCustomTool(guns[Random.Range(0, guns.Length)]);

        ScoreSystem.Instance.AddScore(25);

        EffectsEmitter.Emit("Small_Yellow_Explosion", transform.position);
        Destroy(gameObject);
    }
}