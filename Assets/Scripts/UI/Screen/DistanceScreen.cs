using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ScriptableObjectArchitecture;

namespace UserInterFace
{
    public class DistanceScreen : Screen
    {
        [SerializeField]
        private Slider sliderDistance;
        [SerializeField]
        private TextMeshProUGUI valueText;
        [SerializeField]
        private TypeScreen nextScreen;
        [SerializeField]
        private FloatVariable distanceValue;

        private void Awake()
        {
            UserInterFaceManager.Instance.OnChangeScreen += UpdateScreen;
            sliderDistance.onValueChanged.AddListener(UpdateTextAndValue);
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

        public void OnClickNextButton()
        {
            UserInterFaceManager.Instance.ChangeScreen(nextScreen);
        }

        private void UpdateTextAndValue(float value)
        {
            distanceValue.Value = value;
            valueText.text = $"Distance { 10 + value}";
        }

        public void ResetScreen()
        {
            sliderDistance.value = sliderDistance.minValue;
            UpdateTextAndValue(sliderDistance.value);
        }
    }
}
