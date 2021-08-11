using Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Data
{
    public class LoadingScene : Singleton<LoadingScene>
    {
        [SerializeField]
        private List<SceneIndex> scenes;

        private void Awake()
        {
            foreach (SceneIndex indexScene in scenes)
            {
                SceneManager.LoadScene((int)indexScene, LoadSceneMode.Additive);
            }
        }

        public void ResetAllScenes()
        {
            SceneManager.LoadScene((int)SceneIndex.Initialize, LoadSceneMode.Single);
        }

        public enum SceneIndex
        {
            Initialize,
            Data,
            UI
        }
    }
}
