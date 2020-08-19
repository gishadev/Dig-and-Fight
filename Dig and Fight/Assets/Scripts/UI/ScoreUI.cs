using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
   public TMP_Text scoreText;

    public void UpdateScoreUI(int score)
    {
        scoreText.text = score.ToString();
    }
}
