using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Data;

namespace UserInterFace
{
    public class FireScreen : Screen
    {
        [SerializeField]
        private TextMeshProUGUI scoredText;
        [SerializeField]
        private GameObject buttonFire;
        [SerializeField]
        private GameObject buttonNext;

        private void Awake()
        {
            UserInterFaceManager.Instance.OnChangeScreen += UpdateScreen;
        }

        private void UpdateScreen(TypeScreen currentScreen)
        {
            if (typeScreen.Equals(currentScreen))
            {
                EnableScreen();
            }
            else
            {
                DisableScreen();
            }
        }

        public void OnClickFireButton()
        {
            BulletManager.Instance.ShootBullet();
            buttonFire.SetActive(false);
        }

        public void OnClickNextButton()
        {
            GameManger.Instance.GenerateLevel();
        }

        public void ResetScreen()
        {
            scoredText.text = string.Empty;
            buttonFire.SetActive(true);
            buttonNext.SetActive(false);
        }

        public void ActivateNextButton()
        {
            buttonNext.SetActive(true);
        }

        public void SetScoredPoints(int value)
        {
            scoredText.text = $"Points scored: {value}";
        }
    }
}
