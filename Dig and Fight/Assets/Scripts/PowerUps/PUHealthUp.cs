using UnityEngine;

public class PUHealthUp : MonoBehaviour, IPowerUp
{
    public void Upgrade()
    {
        GameManager.Instance.player.Health++;

        ScoreSystem.Instance.AddScore(15);

        EffectsEmitter.Emit("Small_Green_Explosion", transform.position);
        Destroy(gameObject);
    }
}
