using System.Collections;
using UnityEngine;

public class Highscores : MonoBehaviour
{
    private static Highscores Instance;


    public Highscore[] highscoresList;

    DisplayHighscores displayHS;

    void Awake()
    {
        Instance = this;
        displayHS = GetComponent<DisplayHighscores>();
    }

    public static void AddNewHighscore(string username, int score)
    {
        Instance.StartCoroutine(Instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            Debug.Log("Upload Successful!");
            DownloadHighscores();
        }
        else
            Debug.LogError("Error Uploading: " + www.error);
    }

    public void DownloadHighscores()
    {
        StartCoroutine(DownloadHighscoresFromDatabase());
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            displayHS.OnHighscoresDownloaded(highscoresList);
        }
        else
            Debug.LogError("Error Downloading: " + www.error);
    }

    void FormatHighscores(string textStream)
    {
        string[] entries = textStream.Split(new char[] {'\n'},System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] {'|'});
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
        }
    }
}

public struct Highscore
{
    public string username;
    public int score;
    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }
}
