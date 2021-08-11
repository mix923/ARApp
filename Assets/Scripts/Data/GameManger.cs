using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using Data;
using Architecture;
using UserInterFace;

namespace Data
{
    public class GameManger : Singleton<GameManger>
    {
        [SerializeField]
        private GameObject imageTarget;
        [SerializeField]
        private GameEventBase OnGenerateLevel;
        [SerializeField]
        private GameEventBase OnEndGame;

        private int currentLevel;

        private void Start()
        {
            currentLevel = 0;
            GenerateLevel();
        }

        public void GenerateLevel()
        {
            currentLevel++;

            if (currentLevel > 3)
            {
                imageTarget.SetActive(false);
                OnEndGame?.Raise();
            }

            UserInterFaceManager.Instance.ChangeScreen(TypeScreen.Cannon);
            OnGenerateLevel?.Raise();
        }
    }
}
