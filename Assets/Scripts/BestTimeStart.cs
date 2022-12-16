using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BestTimeStart : MonoBehaviour
{
    public Text bestTimeText;

    private void Start()
    {
        if (PlayerPrefs.HasKey("bestTimeSecond")) 
        {
            float bestTime = PlayerPrefs.GetFloat("bestTimeSecond");
            int bestMinutes = Mathf.FloorToInt(bestTime / 60F);
            int bestSeconds = Mathf.FloorToInt(bestTime - bestMinutes * 60);
            string bestNiceTime = string.Format("{0:0}:{1:00}", bestMinutes, bestSeconds);
            bestTimeText.text = "Лучшее время:  " + bestNiceTime;
        }
    }

}
