using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    #region Singleton
    public static ScoreSystem Instance { private set; get; }
    #endregion

    public int Score { private set; get; }

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int count)
    {
        Score += count;
        UIManager.Instance.scoreUI.UpdateScoreUI(Score);
    }
}
