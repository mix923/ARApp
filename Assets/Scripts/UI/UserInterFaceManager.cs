using Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UserInterFace
{
    public enum TypeScreen { Cannon, Distance, AngleSpeed, Fire, None }

    public class UserInterFaceManager : Singleton<UserInterFaceManager>
    {
        public Action<TypeScreen> OnChangeScreen = delegate { };

        public TypeScreen CurrentScreen { get; private set; }

        public void ChangeScreen(TypeScreen newScreen)
        {
            CurrentScreen = newScreen;
            OnChangeScreen?.Invoke(CurrentScreen);
        }
    }
}
