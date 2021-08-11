using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace UserInterFace
{
    public class ItemTopBar : MonoBehaviour
    {
        [SerializeField]
        private TypeScreen typeScreen;

        [SerializeField]
        private TextMeshProUGUI text;
        [SerializeField]
        private Image image;

        [SerializeField]
        private Color disabledColorText;
        [SerializeField]
        private Color disabledColorImage;
        [SerializeField]
        private Color enabledColorText;
        [SerializeField]
        private Color enabledColorImage;

        private void Awake()
        {
            UserInterFaceManager.Instance.OnChangeScreen += UpdateItemTopBar;
        }

        private void Enable()
        {
            text.color = enabledColorText;
            image.color = enabledColorImage;
        }

        private void Disable()
        {
            text.color = disabledColorText;
            image.color = disabledColorImage;
        }

        public void UpdateItemTopBar(TypeScreen currentScreen)
        {
            if (typeScreen.Equals(currentScreen))
            {
                Enable();
            }
            else
            {
                Disable();
            }
        }
    }
}
