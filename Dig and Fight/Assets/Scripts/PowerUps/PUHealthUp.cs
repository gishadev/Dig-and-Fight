using UnityEngine;

public class PUHealthUp : MonoBehaviour, IPowerUp
{
    public void Upgrade()
    {
        GameManager.Instance.player.Health++;

        ScoreSystem.Instance.AddScore(15);
        Destroy(gameObject);
    }
}
