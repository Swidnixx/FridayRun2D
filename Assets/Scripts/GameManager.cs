using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Singleton
    public static GameManager instance;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Na scenie jest wiêcej ni¿ 1 GameManager");
        }
    }

    // Game Settings
    public float worldScrollingSpeed = 0.1f;
    private float score = 0;
    private int coins = 0;
    private int highScore;

    // UI
    public Text scoreText;
    public GameObject restartButton;
    public Text coinText;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinText.text = coins.ToString();
    }

    private void FixedUpdate()
    {
        score += worldScrollingSpeed;
        scoreText.text = score.ToString("0");
    }

    internal void GameOver()
    {
        Time.timeScale = 0;
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void CoinCollected()
    {
        coins++;
        coinText.text = coins.ToString();
        PlayerPrefs.SetInt("Coins", coins);
    }
}
