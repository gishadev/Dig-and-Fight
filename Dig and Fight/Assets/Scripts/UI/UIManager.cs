using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance { private set; get; }
    #endregion
    public HealthUI healthUI;
    public TimerUI timerUI;
    void Awake()
    {
        Instance = this;
    }
}
