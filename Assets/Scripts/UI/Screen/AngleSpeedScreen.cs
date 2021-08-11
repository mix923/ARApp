using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterFace
{
    public class AngleSpeedScreen : Screen
    {
        [SerializeField]
        private Slider angleSlider;
        [SerializeField]
        private Slider speedSlider;
        [SerializeField]
        private TextMeshProUGUI angleText;
        [SerializeField]
        private TextMeshProUGUI speedText;
        [SerializeField]
        private TypeScreen nextScreen;
        [SerializeField]
        private FloatVariable angleValue;
        [SerializeField]
        private FloatVariable speedValue;

        private void Awake()
        {
            UserInterFaceManager.Instance.OnChangeScreen += UpdateScreen;
            angleSlider.onValueChanged.AddListener(UpdateAngleText);
            speedSlider.onValueChanged.AddListener(UpdateSpeedText);
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

        protected override void DisableScreen()
        {
            base.DisableScreen();

        }

        protected override void EnableScreen()
        {
            base.EnableScreen();
        }

        public void OnClickNextButton()
        {
            UserInterFaceManager.Instance.ChangeScreen(nextScreen);
        }

        private void UpdateAngleText(float value)
        {
            angleValue.Value = value;
            angleText.text = $"{value} °";
        }

        private void UpdateSpeedText(float value)
        {
            speedValue.Value = value;
            speedText.text = $"{value.ToString("N1")} m/s";
        }

        public void ResetScreen()
        {
            angleSlider.value = angleSlider.minValue;
            speedSlider.value = speedSlider.minValue;
            UpdateAngleText(angleSlider.value);
            UpdateSpeedText(speedSlider.value);
        }
    }
}
