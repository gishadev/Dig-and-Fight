using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject quitBtn;
    public GameObject musicOffImg;
    public GameObject soundOffImg;

    void Start()
    {
#if UNITY_WEBGL
        quitBtn.SetActive(false);
#endif
    }

    public void onClick_Play()
    {
        SceneManager.LoadScene(1);

        ClickSound();
    }

    public void onClick_Quit()
    {
        Application.Quit();
    }

    public void onClick_Music()
    {
        AudioManager am = AudioManager.Instance;

        if (am.isMusicMuted)
        {
            AudioManager.Instance.SetMusicVolume(0.15f);
            musicOffImg.SetActive(false);
        }
        else
        {
            AudioManager.Instance.SetMusicVolume(0f);
            musicOffImg.SetActive(true);
        }

        ClickSound();
    }

    public void onClick_Sound()
    {
        AudioManager am = AudioManager.Instance;

        if (am.isSfxMuted)
        {
            AudioManager.Instance.SetSFXVolume(1f);
            soundOffImg.SetActive(false);
        }
        else
        {
            AudioManager.Instance.SetSFXVolume(0f);
            soundOffImg.SetActive(true);
        }

        ClickSound();
    }

    void ClickSound()
    {
        AudioManager.Instance.PlaySFX("Click_01");
    }
}
