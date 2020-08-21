using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Singleton
    public static UIManager Instance { private set; get; }
    #endregion
    // Death Menu.
    public GameObject deathMenu;

    public Button writeScoreBtn;
    public TMP_Text usernameInputField;
    ///////////////////////////////
    [Space]
    public HealthUI healthUI;
    public TimerUI timerUI;
    public AmmoUI ammoUI;
    public ScoreUI scoreUI;
    void Awake()
    {
        Instance = this;
    }
    public void ActivateDeathMenu()
    {
        deathMenu.SetActive(true);
    }
    public void onClick_Restart()
    {
        GameManager.Instance.RestartGame();
    }
    public void onClick_Menu()
    {
        GameManager.Instance.LoadMenu();
    }
    public void onClick_WriteScore()
    {
        // Setting Username //
        string username = usernameInputField.text.Replace(" ", "");
        if (username.Length < 3)
            return;

        // Setting score to highscores //
        Highscores.AddNewHighscore(username,ScoreSystem.Instance.Score);
        writeScoreBtn.interactable = false;
    }
}
