﻿using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance { private set; get; }
    #endregion

    public PlayerController player;

    void Awake()
    {
        Instance = this;    
    }
}
