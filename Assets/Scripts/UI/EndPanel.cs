using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserInterFace
{
    public class EndPanel : MonoBehaviour
    {
        [SerializeField]
        private CanvasGroup canvasGroup;

        private void Awake()
        {
            canvasGroup.alpha = 0f;
        }

        public void OnClickReplayButton()
        {
            LoadingScene.Instance.ResetAllScenes();
        }

        public void OnClickExitButton()
        {
            Application.Quit();
        }
    }
}
