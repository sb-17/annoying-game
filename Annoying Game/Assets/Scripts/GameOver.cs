using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public Button MenuButton;
    public TextMeshProUGUI MenuButtonText;
    public TextMeshProUGUI title;

    void Start()
    {
        int random = Random.Range(1, 5);
        
        if(random == 1)
        {
            title.text = "Looser!";
        }
        else if (random == 2)
        {
            title.text = "How do you feel looser? Haha";
        }
        else if (random == 3)
        {
            title.text = "Game Over looser!";
        }
        else if (random == 4)
        {
            title.text = "You are so bad...";
        }
    }

    public void BackToMenu()
    {
        StartCoroutine(Menu());
    }

    IEnumerator Menu()
    {
        MenuButton.interactable = false;
        MenuButtonText.fontSize = 40;
        MenuButtonText.text = "Going back to menu in: 20 second(s)";

        int i = 19;
        while (i >= 0)
        {
            yield return new WaitForSeconds(1f);

            MenuButtonText.text = "Going back to menu in: " + i.ToString() + " second(s)";

            i--;
        }

        MenuButtonText.fontSize = 80;
        MenuButtonText.text = "Menu";
        MenuButton.interactable = true;
        SceneManager.LoadScene("Menu");
    }
}
