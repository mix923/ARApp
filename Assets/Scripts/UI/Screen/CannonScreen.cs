using ScriptableObjectArchitecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UserInterFace
{
    public class CannonScreen : Screen
    {
        [SerializeField]
        private CannonTypeVariable currentSelectedCannon;
        [SerializeField]
        private Outline outlineCannonNormal;
        [SerializeField]
        private Outline outlineCannonUltra;
        [SerializeField]
        private Outline outlineCannonSpecial;
        [SerializeField]
        private TypeScreen nextScreen;

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

        private void SetClickedCannon(CannonType clickedCannon)
        {
            outlineCannonNormal.enabled = false;
            outlineCannonUltra.enabled = false;
            outlineCannonSpecial.enabled = false;

            if (clickedCannon.Equals(CannonType.Normal))
            {
                outlineCannonNormal.enabled = true;
            }
            else if (clickedCannon.Equals(CannonType.Ultra))
            {
                outlineCannonUltra.enabled = true;
            }
            else
            {
                outlineCannonSpecial.enabled = true;
            }

            currentSelectedCannon.Value = clickedCannon;
        }

        public void OnClickIconCannonNormal()
        {
            SetClickedCannon(CannonType.Normal);
        }

        public void OnClickIconCannonUltra()
        {
            SetClickedCannon(CannonType.Ultra);
        }

        public void OnClickIconCannonSpecial()
        {
            SetClickedCannon(CannonType.Special);
        }

        public void OnClickNextButton()
        {
            UserInterFaceManager.Instance.ChangeScreen(nextScreen);
        }

        public void ResetScreen()
        {
            SetClickedCannon(CannonType.Normal);
        }
    }
}
