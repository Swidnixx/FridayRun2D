using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public PowerupManager powerups;

    public Text batteryInfoText;
    public Button batteryButton;

    public Text magnetInfoText;
    public Button magnetButton;

    int coins;
    public Text coinsText;

    private void OnEnable()
    {
        coins = PlayerPrefs.GetInt("Coins");
        coinsText.text = coins.ToString();
        DisplayBatteryInfo();
        DisplayMagnetInfo();
    }

    void DisplayBatteryInfo()
    {
        string info = "Lvl: " + powerups.battery.level + "\n";
        if(powerups.battery.upgrade == null)
        {
            info += "Max level";
            batteryButton.interactable = false;
        }
        else
        {
            info += powerups.battery.upgradeCost + " coins to upgrade";
        }

        batteryInfoText.text = info;
    }
    public void UpgradeBattery()
    {
        if(coins >= powerups.battery.upgradeCost)
        {
            coins -= powerups.battery.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerups.battery = powerups.battery.upgrade;

            DisplayBatteryInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

    void DisplayMagnetInfo()
    {
        string info = "Lvl: " + powerups.magnet.level + "\n";
        if (powerups.magnet.upgrade == null)
        {
            info += "Max level";
            magnetButton.interactable = false;
        }
        else
        {
            info += powerups.magnet.upgradeCost + " coins to upgrade";
        }

        magnetInfoText.text = info;
    }

    public void UpgradeMagnet()
    {
        if (coins >= powerups.magnet.upgradeCost)
        {
            coins -= powerups.magnet.upgradeCost;
            PlayerPrefs.SetInt("Coins", coins);
            coinsText.text = coins.ToString();

            powerups.magnet = powerups.magnet.upgrade;

            DisplayMagnetInfo();
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }
}
