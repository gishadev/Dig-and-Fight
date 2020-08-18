using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance { private set; get; }
    #endregion
    public HealthUI healthUI;
    void Awake()
    {
        Instance = this;
    }
}
