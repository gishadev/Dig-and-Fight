using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    #region Singleton
    public static ScoreSystem Instance { private set; get; }
    #endregion

    private int score;

    void Awake()
    {
        Instance = this;
    }

    public void AddScore(int count)
    {
        score += count;
        UIManager.Instance.scoreUI.UpdateScoreUI(score);
    }
}
