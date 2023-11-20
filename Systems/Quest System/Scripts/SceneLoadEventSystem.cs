using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DreamersInc.Quests
{
    public class SceneLoadEventSystem : MonoBehaviour
    {
        public class OnSceneLoadEventArgs : EventArgs
        {
            public uint Scene;
        }

        public static EventHandler<OnSceneLoadEventArgs> OnSceneLoad;
        public class OnSceneUnloadEventArgs : EventArgs
        {
            public uint Scene;
        }

        public static EventHandler<OnSceneUnloadEventArgs> OnSceneUnload;

    }
}
