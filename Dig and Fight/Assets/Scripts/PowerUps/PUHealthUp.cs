using UnityEngine;

public class PUHealthUp : MonoBehaviour, IPowerUp
{
    public void Upgrade()
    {
        GameManager.Instance.player.Health++;

        Destroy(gameObject);
    }
}
