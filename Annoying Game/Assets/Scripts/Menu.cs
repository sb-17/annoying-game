using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    public Button playButton;
    public Button quitButton;
    public TextMeshProUGUI playButtonText;
    public TextMeshProUGUI quitButtonText;
    public TextMeshProUGUI highScoreText;

    public static bool canQuit = false;

    void Start()
    {
        highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore").ToString();
        StartCoroutine(Countdown());
    }

    public void Play()
    {
        StartCoroutine(StartGame());
    }

    public void Quit()
    {
        StartCoroutine(QuitGame());
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("Help");
    }

    IEnumerator QuitGame()
    {
        quitButton.interactable = false;
        quitButtonText.fontSize = 30;
        quitButtonText.text = "Quitting game in: 20 second(s)";

        int i = 19;
        while (i >= 0)
        {
            yield return new WaitForSeconds(1f);

            quitButtonText.text = "Quitting game in: " + i.ToString() + " second(s)";

            i--;
        }

        quitButtonText.fontSize = 80;
        quitButtonText.text = "Quit";
        quitButton.interactable = true;
        canQuit = true;
        Application.Quit();
    }

    IEnumerator StartGame()
    {
        playButton.interactable = false;
        playButtonText.fontSize = 50;
        playButtonText.text = "Game starting in: 15 second(s)";

        int i = 14;
        while (i >= 0)
        {
            yield return new WaitForSeconds(1f);

            playButtonText.text = "Game starting in: " + i.ToString() + " second(s)";

            i--;
        }

        playButtonText.fontSize = 120;
        playButtonText.text = "Play";
        playButton.interactable = true;
        SceneManager.LoadScene("Game");
    }

    IEnumerator Countdown()
    {
        playButton.interactable = false;
        playButtonText.fontSize = 50;
        playButtonText.text = "Play button available in: 60 second(s)";

        int i = 59;
        while(i >= 0)
        {
            yield return new WaitForSeconds(1f);

            playButtonText.text = "Play button available in: " + i.ToString() + " second(s)";

            i--;
        }

        playButtonText.fontSize = 120;
        playButtonText.text = "Play";
        playButton.interactable = true;
    }
}
