using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject shopPanel;

    public Text coinsText;
    public Text highscoreText;

    int coins;
    int highscore;

    private void Start()
    {
        //PlayerPrefs.SetInt("Coins", 1000);
        GoToMenu();
    }

    private void UpdateInfo()
    {
        coins = PlayerPrefs.GetInt("Coins", 0);
        highscore = PlayerPrefs.GetInt("Highscore", 0);

        coinsText.text = coins.ToString();
        highscoreText.text = highscore.ToString();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToShop()
    {
        menuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }

    public void GoToMenu()
    {
        shopPanel.SetActive(false);
        menuPanel.SetActive(true);
        UpdateInfo();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
