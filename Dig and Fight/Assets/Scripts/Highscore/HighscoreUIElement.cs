using TMPro;
using UnityEngine;

public class HighscoreUIElement : MonoBehaviour
{
    public TMP_Text usernameText;
    public TMP_Text scoreText;

    public void SetData(string username, string score)
    {
        usernameText.text = username;
        scoreText.text = score;
    }

    public void SetString(string text)
    {
        usernameText.text = text;
        scoreText.text = string.Empty;
    }
}
