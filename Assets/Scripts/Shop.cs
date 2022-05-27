using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public Battery battery;
    public Text batteryInfoText;

    private void OnEnable()
    {
        DisplayBatteryInfo();
    }

    void DisplayBatteryInfo()
    {
        string info = "Lvl: " + battery.level + "\n";
        info += battery.upgradeCost + " coins to upgrade";

        batteryInfoText.text = info;
    }
}
