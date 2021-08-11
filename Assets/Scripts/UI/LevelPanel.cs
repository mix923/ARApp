using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelPanel : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI levelText;

    private int currentLevel;

    private void Awake()
    {
        currentLevel = 0;
    }

    public void UpdateLevelScore()
    {
        currentLevel++;
        levelText.text = $"{currentLevel}/3";
    }
}
