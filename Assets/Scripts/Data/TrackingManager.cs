using Architecture;
using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    public class TrackingManager : Singleton<TrackingManager>
    {
        public Action OnLostTracking = delegate { };
        public Action OnFoundTracking = delegate { };

        public void PauseGame()
        {
            OnFoundTracking?.Invoke();
        }

        public void PlayGame()
        {
            OnLostTracking?.Invoke();
        }
    }
}
