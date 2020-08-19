using UnityEngine;

public class PUSpeedUp : MonoBehaviour, IPowerUp
{
    public float toAdd;

    public void Upgrade()
    {
        if (GameManager.Instance.player.moveSpeed < 1000)
            GameManager.Instance.player.moveSpeed += toAdd;

        ScoreSystem.Instance.AddScore(20);

        EffectsEmitter.Emit("Small_Blue_Explosion", transform.position);
        Destroy(gameObject);
    }
}
