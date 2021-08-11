using Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInterFace;

namespace UserInterFace
{
    public abstract class Screen : MonoBehaviour
    {
        [SerializeField]
        protected CanvasGroup canvasGroup;
        [SerializeField]
        protected TypeScreen typeScreen;

        private void Awake()
        {
            TrackingManager.Instance.OnLostTracking += DisableScreen;
        }

        protected virtual void EnableScreen()
        {
            canvasGroup.alpha = 1f;
            canvasGroup.interactable = true;
            canvasGroup.blocksRaycasts = true;
        }

        protected virtual void DisableScreen()
        {
            canvasGroup.alpha = 0f;
            canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        }
    }
}
