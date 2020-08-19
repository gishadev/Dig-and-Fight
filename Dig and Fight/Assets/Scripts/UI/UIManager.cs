using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance { private set; get; }
    #endregion
    public HealthUI healthUI;
    public TimerUI timerUI;
    public AmmoUI ammoUI;
    public ScoreUI scoreUI;
    void Awake()
    {
        Instance = this;
    }
}
