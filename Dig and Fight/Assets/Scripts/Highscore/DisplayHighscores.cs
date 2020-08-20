using System.Collections;
using UnityEngine;

public class DisplayHighscores : MonoBehaviour
{
    public HighscoreUIElement[] hsElements;

    Highscores hsManager;

    void Awake()
    {
        hsManager = GetComponent<Highscores>();
    }

    void Start()
    {
        for (int i = 0; i < hsElements.Length; i++)
            hsElements[i].SetString("<>");

        StartCoroutine(RefreshHighscores());
    }

    IEnumerator RefreshHighscores()
    {
        while (true)
        {
            hsManager.DownloadHighscores();
            yield return new WaitForSeconds(30f);
        }
    }

    public void OnHighscoresDownloaded(Highscore[] hsList)
    {
        for (int i = 0; i < hsElements.Length; i++)
            if (i < hsList.Length)
                hsElements[i].SetData(hsList[i].username, hsList[i].score.ToString());
    }
}
