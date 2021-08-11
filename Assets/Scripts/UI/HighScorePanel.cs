using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScorePanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI highScoreText;

    private int currentHighScore;

    private void Awake()
    {
        currentHighScore = 0;
    }

    public void UpdateHighScore(int value)
    {
        if(value > currentHighScore)
        {
            currentHighScore = value;
            highScoreText.text = currentHighScore.ToString();
        }
    }
}
